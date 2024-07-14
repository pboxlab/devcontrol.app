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
        private          int?                  _modelProjetoId;
        private          ProgramTypeEnum?      _modelTipoId;
        private          bool                  _enableLoad            = false;

        private readonly ProcessService        _processService        = new();
        private readonly ProjectRepository     _projetoRepository     = new();
        private readonly ProgramRepository     _programaRepository    = new();
        private readonly LogsProcessRepository _logsProcessRepository = new();

        private          List<ProgramEntity>   _programasAll          = new();
        private          List<ProgramEntity>   _programas             = new();
        private          ProgramFormWindow     _programFormWindow     = new();

        public WindowMonitor()
        {
            InitializeComponent();
            _programFormWindow.ProgramsReloaded += (s, e) => LoadProgramas();
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
            List<ProjectEntity> projetos = new();

            try
            {
                projetos = await _projetoRepository.LoadRecordsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar carregar os projetos\n\nMensagem:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            try
            {
                _programas = await _programaRepository.LoadRecords(new()
                {
                    ProjectId = _modelProjetoId,
                    Type = _modelTipoId
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar carregar os programas\n\nMensagem:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                    ProgramTypeEnum.DotNet  => Properties.Resources.iconDotNet20x,
                    ProgramTypeEnum.Angular => Properties.Resources.iconAngular20x,
                    ProgramTypeEnum.NodeJs  => Properties.Resources.iconNodeJs20x,
                    ProgramTypeEnum.PHP     => Properties.Resources.iconPhp20x,
                    _                       => Properties.Resources.iconAnyFile20x,
                }
            });

            var labelList = new List<(string Text, string Name, int Width)>()
            {
                new (projeto.Name!,            $"labelProgramaNome_{projeto.Id}", 150),
                new (projeto.ProjectName!,     $"labelProjetoNome_{projeto.Id}",  150),
                new (projeto.Port.ToString()!, $"labelProgramaPorta_{projeto.Id}", 50),
            };
            var p = 25;
            foreach (var label in labelList)
            {
                panel.Controls.Add(PanelComponents.LabelPanel(label.Text, label.Name, label.Width, p));
                p = p + label.Width;
            }

            var iconEditor = (projeto.Type == ProgramTypeEnum.DotNet) ? Properties.Resources.btnOpenIDE : Properties.Resources.btnOpenEditor;
            var buttonList = new List<(object Text, int Width, string Tag, string Function)>
            {
                new(Properties.Resources.btnDelete,      25, $"btnApagar_{projeto.Id}",      "btnApagarProjeto_Click"),
                new(Properties.Resources.btnEdit,        25, $"btnEditar_{projeto.Id}",      "btnFormularioProjeto_Click"),
                new(Properties.Resources.btnOpenFolder,  25, $"btnExplorar_{projeto.Id}",    "btnOpenDirectory_Click"),
                new(Properties.Resources.iconGit20x,     25, $"btnGit_{projeto.Id}",         "btnOpenGit_Click"),
                new(iconEditor,                          25, $"btnAbrir_{projeto.Id}",       "btnOpenEditor_Click"),
                new(Properties.Resources.btnLog,         25, $"btnLog_{projeto.Id}",         "btnOpenLog_Click"),
                new("Start",                            100, $"btnStart_{projeto.Id}",       "btnService_Click"),
            };

            var b = widthTotal;
            foreach (var button in buttonList)
            {
                b = (b - button.Width) - 5;
                panel.Controls.Add(ButtonPanel(projeto, button.Text, button.Tag, button.Width, b, button.Function));
            }

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

        private Button ButtonPanel(ProgramEntity programa, object text, string tag, int width, int px, string? funcao = null)
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
                    case "btnApagarProjeto_Click":
                        button.Click += (s, e) => BtnApagarProjeto_Click(programa);
                        break;
                    case "btnFormularioProjeto_Click":
                        button.Click += (s, e) => BtnFormularioProjeto_Click(programa);
                        break;
                    case "btnOpenDirectory_Click":
                        button.Click += (s, e) => DialogCommon.OpenPathClick(programa.Path!);
                        break;
                    case "btnOpenGit_Click":
                        button.Click += (s, e) => DialogCommon.OpenPathClick(programa.RepositoryUrl!, "browser");
                        break;
                    case "btnOpenEditor_Click":
                        button.Click += (s, e) => {
                            if (programa.Type == ProgramTypeEnum.DotNet)
                            {
                                DialogCommon.OpenPathClick(programa.Workspace!);
                            }
                            else
                            {
                                DialogCommon.OpenPathClick(programa.Path!, "cmd.exe", "/c code .");
                            }
                        };
                        break;
                    case "btnOpenLog_Click":
                        button.Click += (s, e) =>
                        {
                            WindowProgramaLog _winProjetoLog = new(programa);
                            _winProjetoLog.Show();
                        };
                        break;
                    case "btnService_Click":
                        button.Click += (s, e) => BtnStartService_Click(programa);
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
            if (projeto.Button == null) return;

            switch (status)
            {
                case ButtonStatusEnum.Running:
                    projeto.Button.Enabled = true;
                    projeto.Button.Text = $"Stop: [{projeto.Process.Id}]";
                    projeto.Button.BackColor = Color.LightGreen;
                    projeto.Button.UseVisualStyleBackColor = false;
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

        private async void RegisterLog(ProgramEntity projeto, string type, string? logValue, object? sender, EventArgs? e)
        {
            var dto = new LogsProcessDto()
            {
                SoftwareId = projeto.Id,
                PID = projeto.Process!.Id,
                Type = type,
                LogValue = logValue ?? ""
            };

            try
            {
                await _logsProcessRepository.ExecuteQueryAsync(dto, TypeQueryExecuteEnum.Insert);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar salvar o log.\n\nMensagem:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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

        private void BtnStartService_Click(ProgramEntity projeto)
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

        private void BtnFormularioProjeto_Click(ProgramEntity? projeto = null)
        {
            _programFormWindow.LoadDetails(projeto);
            _programFormWindow.ShowDialog();
        }

        private async void BtnApagarProjeto_Click(ProgramEntity projeto)
        {
            var result = MessageBox.Show($"Tem certeza que deseja apagar o projeto {projeto.Name}? \n\nNem o código ou processo sofrerão alterações.", "Apagar Projeto", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                try
                {
                    await _programaRepository.ExecuteQueryAsync(new ProgramDto { Id = projeto.Id }, TypeQueryExecuteEnum.Delete);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao tentar apagar o programa.\n\nMensagem:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoadProgramas();
            }
        }
    }
}
