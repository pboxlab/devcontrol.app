using DevControl.App.Common;
using DevControl.App.Data.Dtos;
using DevControl.App.Data.Entities;
using DevControl.App.Data.Enum;
using DevControl.App.Data.Repositories;
using DevControl.App.Services;
using System.Diagnostics;

namespace DevControl.App.Windows
{
    public partial class WindowMonitor : Form
    {
        private int? _modelProjetoId;
        private ProgramTypeEnum? _modelTipoId;
        private bool _enableLoad = false;

        private readonly ProcessService _processService = new();
        private readonly ProjectRepository _projetoRepository = new();
        private readonly ProgramRepository _programaRepository = new();
        private readonly LogsProcessRepository _logsProcessRepository = new();

        private List<ProgramEntity> _programasAll = new();
        private List<ProgramEntity> _programas = new();
        private ProgramFormWindow _programFormWindow = new();

        public WindowMonitor()
        {
            _programFormWindow.ProgramsReloaded += ReloadProgramas;

            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            DataFiltroTipos();
            DataFiltroProjetos();

            _enableLoad = true;
            LoadProgramas();
        }

        public async void DataFiltroProjetos()
        {
            var projetos = await _projetoRepository.LoadRecordsAsync();
            projetos.Insert(0, new() { Id = 0, Name = "", Path = "" });
            boxFiltroProjeto.DataSource = projetos;
        }

        public void DataFiltroTipos()
        {
            var types = new ProgramTypeEntity().ListType();
            types.Insert(0, new() { Id = 0, Name = "" });
            boxFiltroTipo.DataSource = types;
        }

        private void BoxFilterProjetos_SelectedIndexChanged(object sender, EventArgs e)
        {
            _modelTipoId = null;
            _modelProjetoId = null;

            int selectedType, selectedProject;

            if (boxFiltroTipo.SelectedValue != null && int.TryParse(boxFiltroTipo.SelectedValue.ToString(), out selectedType) && selectedType != 0)
            {
                _modelTipoId = (ProgramTypeEnum)selectedType;
            }

            if (boxFiltroProjeto.SelectedValue != null && int.TryParse(boxFiltroProjeto.SelectedValue.ToString(), out selectedProject) && selectedProject != 0)
            {
                _modelProjetoId = selectedProject;
            }

            if (_enableLoad)
            {
                LoadProgramas();
            }
        }

        private async void LoadProgramas()
        {
            _programas = await _programaRepository.LoadRecords(new()
            {
                ProjectId = _modelProjetoId,
                Type = _modelTipoId
            });

            panelMotiporProgramas.Controls.Clear();

            int y = 10;
            int isScroll = _programas.Count > 14 ? 20 : 0;

            foreach (var projeto in _programas)
            {
                AddControlPanel(projeto, y, isScroll);
                y += 45;
            }
        }

        private void AddControlPanel(ProgramEntity projeto, int y, int isScroll = 0)
        {
            int widthTotal = 1040 - isScroll;

            var panel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(0, y),
                Size = new Size(widthTotal, 40),
                BackColor = Color.White,
                Tag = $"row{projeto.Id}",
            };

            panel.Controls.Add(new PictureBox
            {
                Name = $"iconType_{projeto.Id}",
                Location = new Point(10, 9),
                Size = new Size(20, 20),
                Image = projeto.Type switch
                {
                    ProgramTypeEnum.DotNet => Properties.Resources.iconDotNet20x,
                    ProgramTypeEnum.Angular => Properties.Resources.iconAngular20x,
                    ProgramTypeEnum.NodeJs => Properties.Resources.iconNodeJs20x,
                    ProgramTypeEnum.PHP => Properties.Resources.iconPhp20x,
                    _ => Properties.Resources.iconAnyFile20x,
                }
            });

            var labelList = new List<(string Text, string Name, int Width)>()
            {
                new (projeto.Name!,            $"labelProgramaNome_{projeto.Id}", 150),
                new (projeto.ProjectName!,     $"labelProjetoNome_{projeto.Id}",  150),
                new (projeto.Port.ToString()!, $"labelProjetoPorta_{projeto.Id}", 50),
            };
            var p = 25;
            foreach (var label in labelList)
            {
                panel.Controls.Add(PanelComponents.LabelPanel(label.Text, label.Name, label.Width, p));
                p = p + label.Width;
            }

            var buttonList = new List<(object Text, int Width, string Tag, string Function)>
            {
                new(Properties.Resources.btnDelete, 25,     $"btnApagar_{projeto.Id}",   "btnApagarProjeto_Click"),
                new(Properties.Resources.btnEdit, 25,       $"btnEditar_{projeto.Id}",   "btnEditarProjeto_Click"),
                new(Properties.Resources.btnOpenFolder, 25, $"btnExplorar_{projeto.Id}", "btnOpenDirectory_Click")
            };

            if (projeto.Type == ProgramTypeEnum.DotNet && !string.IsNullOrEmpty(projeto.Workspace))
            {
                buttonList.Add(new(Properties.Resources.btnOpenIDE, 25, $"btnAbrir_{projeto.Id}", "btnOpenVisualStudio_Click"));
            }
            else
            {
                buttonList.Add(new(Properties.Resources.btnOpenEditor, 25, $"btnAbrir_{projeto.Id}", "btnOpenVsCode_Click"));
            }

            buttonList.Add(new(Properties.Resources.iconGit20x, 25, $"btnGit_{projeto.Id}", "btnOpenGit_Click"));
            buttonList.Add(new("Start", 50, $"btnStart_{projeto.Id}", "btnStartService_Click"));
            buttonList.Add(new(Properties.Resources.btnLog, 25, $"btnLog_{projeto.Id}", "btnOpenLog_Click"));

            var b = widthTotal;
            foreach (var button in buttonList)
            {
                b = (b - button.Width) - 5;
                panel.Controls.Add(ButtonPanel(projeto, button.Text, button.Tag, button.Width, b, button.Function));
            }

            var wL = 50;
            panel.Controls.Add(PanelComponents.LabelPanel("", $"labelProjetoProcessId_{projeto.Id}", wL, (b - wL - 5)));

            panelMotiporProgramas.Controls.Add(panel);

            projeto.Button = FindButtonByTag($"btnStart_{projeto.Id}");

            var process = GetProcessProjeto(projeto);
            if (process != null)
            {
                projeto.Process = process;
                projeto.PID = process.Id;
                ChangeButton(projeto, ButtonStatusEnum.Running);
            }
        }

        private Button ButtonPanel(ProgramEntity projeto, object text, string tag, int width, int px, string? funcao = null)
        {
            var button = new Button();

            if (text is System.Drawing.Image image)
            {
                button.Image = image;
            }
            else
            {
                button.Text = text.ToString();
            }

            button.Location = new Point(px, 6);
            button.Size = new Size(width, 25);
            button.Tag = tag;


            if (!string.IsNullOrEmpty(funcao))
            {
                switch (funcao)
                {
                    case "btnStartService_Click":
                        button.Click += (s, e) => btnStartService_Click(projeto);
                        break;
                    case "btnEditarProjeto_Click":
                        button.Click += (s, e) => btnEditarProjeto_Click(projeto);
                        break;
                    case "btnApagarProjeto_Click":
                        button.Click += (s, e) => btnApagarProjeto_Click(projeto);
                        break;
                    case "btnOpenDirectory_Click":
                        button.Click += (s, e) => DialogCommon.OpenDirectoryClick(projeto.Path ?? "");
                        break;
                    case "btnOpenVsCode_Click":
                        button.Click += (s, e) => btnOpenVsCode_Click(projeto);
                        break;
                    case "btnOpenVisualStudio_Click":
                        button.Click += (s, e) => btnOpenVisualStudio_Click(projeto);
                        break;
                    case "btnOpenLog_Click":
                        button.Click += (s, e) => btnOpenLog_Click(projeto);
                        break;
                    case "btnOpenGit_Click":
                        button.Click += (s, e) => btnOpenGit_Click(projeto);
                        break;
                }
            }
            return button;
        }

        private Button FindButtonByTag(string tag)
        {
            foreach (Control control in panelMotiporProgramas.Controls)
            {
                if (control is Panel panel)
                {
                    var button = panel.Controls.OfType<Button>().FirstOrDefault(b => b.Tag != null && b.Tag.ToString() == tag);
                    if (button != null)
                    {
                        return button;
                    }
                }
            }
            return null;
        }

        public void ReloadProgramas(object sender, EventArgs e)
        {
            LoadProgramas();
        }

        private Process? GetProcessProjeto(ProgramEntity projeto)
        {
            if (!string.IsNullOrEmpty(projeto.ProcessName) && _processService.IsProcessRunning(projeto.ProcessName))
            {
                var processByName = Process.GetProcessesByName(projeto.ProcessName).FirstOrDefault();
                if (processByName != null && processByName.Id != 0)
                {
                    return processByName;
                }
            }
            else if (projeto.Port != null && projeto.Port != 0)
            {
                var processByPort = _processService.GetProcessUsingPort(projeto.Port ?? 0);
                if (processByPort != null && processByPort.Id != 0)
                {
                    return processByPort;
                }
            }

            return null;

            //process.OutputDataReceived += (sender, e) => RegisterLog(projeto, "Output", e.Data, sender, e);
            //process.ErrorDataReceived += (sender, e) => RegisterLog(projeto, "Error", e.Data, sender, e);
            //process.Exited += (sender, e) => RegisterLog(projeto, "Exited", process.ExitCode.ToString(), sender, e);

            //process.Start();
            //process.BeginOutputReadLine();
            //process.BeginErrorReadLine();
        }

        private void SetTextLabel(string name, string text)
        {
            Control[] foundControls = this.Controls.Find(name, true);
            if (foundControls.Length > 0 && foundControls[0] is Label)
            {
                Label label = (Label)foundControls[0];
                label.Text = text;
            }
        }

        private void ChangeButton(ProgramEntity projeto, ButtonStatusEnum status)
        {
            SetTextLabel($"labelProjetoProcessId_{projeto.Id}", "");

            if (projeto.Button == null) return;

            switch (status)
            {
                case ButtonStatusEnum.Running:
                    projeto.Button.Enabled = true;
                    projeto.Button.Text = "Stop";
                    projeto.Button.BackColor = Color.LightGreen;
                    projeto.Button.UseVisualStyleBackColor = false;
                    SetTextLabel($"labelProjetoProcessId_{projeto.Id}", ((projeto.Process ?? new Process()).Id).ToString());
                    break;
                case ButtonStatusEnum.Loading:
                    projeto.Button.Enabled = false;
                    projeto.Button.Text = "Loading";
                    break;
                case ButtonStatusEnum.Stopped:
                    projeto.Button.Enabled = true;
                    projeto.Button.Text = "Play";
                    projeto.Button.UseVisualStyleBackColor = true;
                    projeto.Process = null;
                    break;
            }
        }

        private void StartProcess(ProgramEntity projeto, string executor, string arguments)
        {
            var processInfo = new ProcessStartInfo(executor, arguments)
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                WorkingDirectory = projeto.Path,
                CreateNoWindow = true
            };

            var process = new Process
            {
                StartInfo = processInfo,
                EnableRaisingEvents = true
            };

            process.OutputDataReceived += (sender, e) => RegisterLog(projeto, "Output", e.Data, sender, e);
            process.ErrorDataReceived += (sender, e) => RegisterLog(projeto, "Error", e.Data, sender, e);
            process.Exited += (sender, e) => RegisterLog(projeto, "Exited", process.ExitCode.ToString(), sender, e);

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            projeto.Process = process;

            ChangeButton(projeto, ButtonStatusEnum.Running);
        }

        private void RegisterLog(ProgramEntity projeto, string type, string? logValue, object? sender, EventArgs? e)
        {
            int? processId = null;

            try
            {
                processId = projeto.Process.Id;
            }
            catch (Exception)
            {

            }


            var dto = new LogsProcessDto()
            {
                SoftwareId = projeto.Id,
                PID = processId,
                Type = type,
                LogValue = logValue ?? ""
            };

            _logsProcessRepository.ExecuteQueryAsync(dto, TypeQueryExecuteEnum.Insert);
        }

        private void StopProcess(ProgramEntity projeto)
        {
            if (projeto.Process == null)
            {
                ChangeButton(projeto, ButtonStatusEnum.Stopped);
                return;
            }

            try
            {
                projeto.Process.Kill();
                projeto.Process.WaitForExit(5000);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar parar o processo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!projeto.Process.HasExited)
                {
                    MessageBox.Show("O processo não pôde ser encerrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    projeto.Process.Dispose();
                    ChangeButton(projeto, ButtonStatusEnum.Stopped);
                }
            }

        }

        private void StartProcessByType(ProgramEntity projeto)
        {
            var process = new Process();

            if (projeto.Type == ProgramTypeEnum.DotNet)
            {
                process = GetProcessProjeto(projeto);

                if (process == null)
                {
                    StartProcess(projeto, "cmd.exe", $"/c {projeto.Command}");
                    return;
                }

                projeto.Process = process;
                ChangeButton(projeto, ButtonStatusEnum.Running);
                return;
            }


            else if (projeto.Type == ProgramTypeEnum.Angular)
            {
                process = GetProcessProjeto(projeto);

                var npmPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "nodejs", "node_modules", "npm", "bin", "npm-cli.js");

                if (process == null)
                {
                    StartProcess(projeto, "node.exe", $"\"{npmPath}\" start");
                    return;
                }

                if (process.ProcessName != "node")
                {
                    MessageBox.Show($"A porta {projeto.Port} já está sendo utilizada por outro programa que não é o Node.exe.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                projeto.Process = process;
                ChangeButton(projeto, ButtonStatusEnum.Running);
                return;
            }

            else if (projeto.Type == ProgramTypeEnum.PHP)
            {
                process = GetProcessProjeto(projeto);

                if (process == null)
                {
                    var npmPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "nodejs", "node_modules", "npm", "bin", "npm-cli.js");

                    StartProcess(projeto, @"C:\xampp\php\php.exe", $"{projeto.Path}\\artisan serve");
                    return;
                }

                projeto.Process = process;
                ChangeButton(projeto, ButtonStatusEnum.Running);
                return;

            }


            StartProcess(projeto, "cmd.exe", $"/c {projeto.Command}");
            return;
        }

        private void btnStartService_Click(ProgramEntity projeto)
        {

            ChangeButton(projeto, ButtonStatusEnum.Loading);

            if (projeto.Process == null)
            {
                StartProcessByType(projeto);
            }
            else
            {
                StopProcess(projeto);
            }
        }

        private void btnCadastrarProjeto_Click(object sender, EventArgs e)
        {
            _programFormWindow.LoadDetails();
            _programFormWindow.ShowDialog();
        }

        private void btnEditarProjeto_Click(ProgramEntity projeto)
        {
            _programFormWindow.LoadDetails(projeto);
            _programFormWindow.ShowDialog();
        }

        private void btnApagarProjeto_Click(ProgramEntity projeto)
        {
            var result = MessageBox.Show($"Tem certeza que deseja remover o projeto {projeto.Name}? \n\nNem o código ou processo sofrerão alterações.", "Apagar Projeto", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                _programaRepository.ExecuteQuery(new ProgramDto { Id = projeto.Id }, TypeQueryExecuteEnum.Delete);
                LoadProgramas();
            }
        }

        private void btnOpenVsCode_Click(ProgramEntity projeto)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo("cmd.exe", "/c code .")
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WorkingDirectory = projeto.Path,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                }
            };
            process.Start();
        }

        private void btnOpenVisualStudio_Click(ProgramEntity projeto)
        {
            if (Directory.Exists(projeto.Path))
            {
                Process.Start("explorer.exe", projeto.Workspace!);
            }
            else
            {
                MessageBox.Show("Diretório não encontrado");
            }
        }

        private void btnOpenLog_Click(ProgramEntity programa)
        {
            WindowProgramaLog _winProjetoLog = new(programa);
            _winProjetoLog.Show();
        }

        private void btnOpenGit_Click(ProgramEntity projeto)
        {
            if (string.IsNullOrEmpty(projeto.RepositoryUrl))
            {
                MessageBox.Show($"O projeto {projeto.Name} não tem um diretório configurado.");
                return;
            }

            try
            {
                Process.Start(new ProcessStartInfo(projeto.RepositoryUrl) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível abrir o endereço {projeto.RepositoryUrl}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnReloadProgramas_click(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                LoadProgramas(); // Chama a função desejada
            }
        }

        private void btnReloadProgramas_Click(object sender, EventArgs e)
        {
            LoadProgramas();
        }
    }
}
