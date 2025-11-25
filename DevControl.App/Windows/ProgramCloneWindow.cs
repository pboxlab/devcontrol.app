using DevControl.App.Common;
using DevControl.App.Data.Dtos;
using DevControl.App.Data.Entities;
using DevControl.App.Data.Enum;
using DevControl.App.Data.Models;
using DevControl.App.Data.Repositories;
using Octokit;

namespace DevControl.App.Windows
{
    public partial class ProgramCloneWindow : Form
    {
        private readonly ProjectRepository _projectRepository = new();
        private readonly ProgramRepository _programRepository = new();

        public ProgramCloneWindow()
        {
            InitializeComponent();
            LoadComboBoxDataAsync();
        }

        private void ResetForm()
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
            Close();
        }

        private async void LoadComboBoxDataAsync()
        {
            List<ProjectEntity> projects = new();

            try
            {
                projects = await _projectRepository.LoadRecordsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar carregar os projetos.\n\nMensagem:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (projects != null)
            {
                projects.Insert(0, new() { Id = 0, Name = "", Path = "" });
            }
            comboBoxProject.DataSource = projects;
            comboBoxProject.DisplayMember = "Name";
            comboBoxProject.ValueMember = "Id";
        }

        private void btnBrowseProgramPath_Click(object sender, EventArgs e)
        {
            textProgramPath.Text = DialogCommon.ChooseDirectory();
        }

        private void btnCancelProgram_Click(object sender, EventArgs e)
        {
            ResetForm();
            Close();
        }

        private bool ValidateForm()
        {
            if (comboBoxProject.SelectedValue == null || (int)comboBoxProject.SelectedValue == 0)
            {
                MessageBox.Show("Selecione um projeto", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(textProgramPath.Text))
            {
                MessageBox.Show("Informe a pasta do programa", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private async void btnSaveProgram_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            DialogCommon.OpenPathClick(textProgramPath.Text, "cmd.exe", $"/c git clone {textProgramRepositoryUrl.Text}");

            var dto = new ProgramDto
            {
                RepositoryUrl = textProgramRepositoryUrl.Text,
                ProjectId = int.Parse(comboBoxProject.SelectedValue.ToString()!),
                Path = textProgramPath.Text,
                //ProcessName = comboBoxProgramStart.Text,
                //Command = textProgramCommand.Text,
                //Workspace = _solutionFilePath,
                //Type = (ProgramTypeEnum)comboBoxProgramType.SelectedValue
            };

            ProgramEntity programa = new();

            try
            {
                programa = await _programRepository.ExecuteQueryAsync(dto, TypeQueryExecuteEnum.Insert);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar salvar o programa.\n\nMensagem:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ResetForm();
            Close();

            ProgramFormWindow _programFormWindow = new();
            _programFormWindow.LoadDetails(programa);
            _programFormWindow.ShowDialog();
        }
    }
}
