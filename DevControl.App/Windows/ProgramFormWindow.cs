using DevControl.App.Common;
using DevControl.App.Data.Dtos;
using DevControl.App.Data.Entities;
using DevControl.App.Data.Enum;
using DevControl.App.Data.Repositories;
using DevControl.App.Services;

namespace DevControl.App.Windows
{
    public partial class ProgramFormWindow : Form
    {
        private readonly ProjectRepository _projectRepository = new();
        private readonly ProgramRepository _programRepository = new();

        public ProgramEntity Program { get; private set; } = new();
        private List<string> _projectFiles = new();
        private string? _solutionFilePath;

        public event EventHandler? ProgramsReloaded;

        public ProgramFormWindow()
        {
            InitializeComponent();
            LoadComboBoxDataAsync();
        }

        public void LoadDetails(ProgramEntity? program = null)
        {
            Text = program != null ? "Editar Programa" : "Novo Programa";
            Program = program ?? new ProgramEntity();

            if (program != null)
            {
                textProgramName.Text = program.Name;
                textProgramPort.Text = program.Port.ToString();
                textProgramPath.Text = program.Path;
                textProgramRepositoryUrl.Text = program.RepositoryUrl;
                textProgramCommand.Text = program.Command;
                comboBoxProgramStart.Text = program.ProcessName;
                comboBoxProgramType.SelectedValue = (int)program.Type;
                comboBoxProject.SelectedValue = program.ProjectId;

                var scanner = new FileScannerService(textProgramPath.Text);
                if (LoadDotNetProjectFiles(scanner)) return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
            Close();
        }

        private async void LoadComboBoxDataAsync()
        {
            var projects = await _projectRepository.LoadRecordsAsync();

            if (projects != null)
            {
                projects.Insert(0, new() { Id = 0, Name = "", Path = "" });
            }
            comboBoxProject.DataSource = projects;
            comboBoxProject.DisplayMember = "Name";
            comboBoxProject.ValueMember = "Id";

            var types = new ProgramTypeEntity().ListType();
            types.Insert(0, new() { Id = 0, Name = "" });

            comboBoxProgramType.DataSource = types;
            comboBoxProgramType.DisplayMember = "Name";
            comboBoxProgramType.ValueMember = "Id";

            comboBoxProgramStart.Text = Program.ProcessName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var dto = new ProgramDto
            {
                Id = Program.Id,
                Port = string.IsNullOrEmpty(textProgramPort.Text) ? null : int.Parse(textProgramPort.Text),
                Name = textProgramName.Text,
                RepositoryUrl = textProgramRepositoryUrl.Text,
                ProjectId = int.Parse(comboBoxProject.SelectedValue.ToString()!),
                Path = textProgramPath.Text,
                ProcessName = comboBoxProgramStart.Text,
                Command = textProgramCommand.Text,
                Workspace = _solutionFilePath,
                Type = (ProgramTypeEnum)comboBoxProgramType.SelectedValue
            };

            var queryType = Program.Id == 0 ? TypeQueryExecuteEnum.Insert : TypeQueryExecuteEnum.Update;
            _programRepository.ExecuteQuery(dto, queryType);

            ResetForm();
            Close();
            ProgramsReloaded?.Invoke(this, EventArgs.Empty);
        }

        private bool ValidateForm()
        {
            if (comboBoxProject.SelectedValue == null || (int)comboBoxProject.SelectedValue == 0)
            {
                MessageBox.Show("Selecione um projeto", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(textProgramName.Text))
            {
                MessageBox.Show("Informe o nome do programa", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(textProgramPath.Text))
            {
                MessageBox.Show("Informe a pasta do programa", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBoxProgramType.SelectedValue == null || (int)comboBoxProgramType.SelectedValue == 0)
            {
                MessageBox.Show("Selecione o tipo do programa", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ResetForm()
        {
            textProgramName.Clear();
            textProgramPort.Clear();
            textProgramPath.Clear();
            textProgramRepositoryUrl.Clear();
            textProgramCommand.Clear();
            comboBoxProgramStart.ResetText();
            comboBoxProgramType.ResetText();
            comboBoxProject.ResetText();

            _projectFiles.Clear();
            comboBoxProgramStart.DataSource = null;
            comboBoxProgramStart.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void comboBoxProgramStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProgramStart.SelectedValue != null)
            {
                SetProgramCommand(comboBoxProgramStart.SelectedValue.ToString()!);
            }
        }

        private void SetProgramCommand(string projectName)
        {
            var fullPath = _projectFiles.Find(file => file.Contains(projectName));
            if (fullPath != null)
            {
                var cmd = fullPath.Replace($"\\{projectName}.csproj", "").Replace($"{textProgramPath.Text}", ".");
                textProgramCommand.Text = Program.Id != 0 && !string.IsNullOrEmpty(Program.Command)
                    ? Program.Command
                    : $"dotnet run --project {cmd}";
            }
        }

        private void SetProgramRepositoryUrl(string programPath)
        {
            var gitInfo = new GitRepositoryInfoService(programPath);
            if (gitInfo != null)
            {
                textProgramRepositoryUrl.Text = MasksCommon.ConvertSshToHttp(gitInfo.RemoteUrl);
            }
        }

        private bool LoadDotNetProjectFiles(FileScannerService scanner)
        {
            _projectFiles = scanner.FindProjectFiles("*.csproj");
            if (_projectFiles.Count > 0)
            {
                comboBoxProgramType.SelectedValue = 1;

                var solutionFile = scanner.FindProjectFiles("*.sln").FirstOrDefault();
                if (solutionFile != null)
                {
                    _solutionFilePath = solutionFile;
                    if (Program.Id == 0)
                    {
                        textProgramName.Text = Path.GetFileNameWithoutExtension(solutionFile);
                    }

                    comboBoxProgramStart.DataSource = _projectFiles.Select(file => Path.GetFileNameWithoutExtension(file)).ToList();
                    comboBoxProgramStart.DropDownStyle = ComboBoxStyle.DropDownList;

                    comboBoxProgramStart.Text = Program.ProcessName;
                }

                return true;
            }

            return false;
        }

        private bool LoadPhpProjectFiles(FileScannerService scanner)
        {
            _projectFiles = scanner.FindProjectFiles("*.php");
            if (_projectFiles.Count > 0)
            {
                comboBoxProgramType.SelectedValue = 4;
                return true;
            }

            return false;
        }

        private void btnSelectDirectory_Click(object sender, EventArgs e)
        {
            textProgramPath.Text = DialogCommon.ChooseDirectory(Program.Path) ?? textProgramPath.Text;
            SetProgramRepositoryUrl(textProgramPath.Text);

            var scanner = new FileScannerService(textProgramPath.Text);
            if (LoadDotNetProjectFiles(scanner)) return;
            if (LoadPhpProjectFiles(scanner)) return;
        }
    }
}
