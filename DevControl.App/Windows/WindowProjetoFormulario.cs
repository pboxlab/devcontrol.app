using DevControl.App.Common;
using DevControl.App.Data.Dtos;
using DevControl.App.Data.Entities;
using DevControl.App.Data.Enum;
using DevControl.App.Data.Repositories;

namespace DevControl.App.Windows
{
    public partial class WindowProjetoFormulario : Form
    {
        private readonly ProjectRepository ProjetosRepository = new();
        public           ProjectEntity     Projeto            = new();
        public  event    EventHandler?     ReloadProjetos;

        public WindowProjetoFormulario()
        {
            InitializeComponent();
        }

        public void LoadDetails(ProjectEntity? projeto = null)
        {
            Text    = projeto != null ? "Editar Projeto" : "Novo Projeto";
            Projeto = projeto ?? new();

            if (projeto != null)
            {   
                textProjetoName.Text = Projeto.Name;
                textProjetoPath.Text = Projeto.Path;
            }
        }

        private void ResetForm()
        {
            textProjetoName.Text = string.Empty;
            textProjetoPath.Text = string.Empty;
        }

        private async void btnProjetoSalvar_Click(object sender, EventArgs e)
        {
            var dto = new ProjectDto
            {
                Id = Projeto.Id,
            };

            if (string.IsNullOrEmpty(textProjetoName.Text))
            {
                MessageBox.Show($"Informe o nome do projeto", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dto.Name = textProjetoName.Text;

            if (string.IsNullOrEmpty(textProjetoPath.Text))
            {
                MessageBox.Show($"Informe o diretório principal", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dto.Path = textProjetoPath.Text;

            TypeQueryExecuteEnum commandExecute = (Projeto.Id == 0) ? TypeQueryExecuteEnum.Insert : TypeQueryExecuteEnum.Update;

            try
            {
                await ProjetosRepository.ExecuteQueryAsync(dto, commandExecute);                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar salvar o projeto.\n\nMensagem:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ReloadProjetos?.Invoke(this, EventArgs.Empty);

            ResetForm();
            Close();
        }

        private void btnProjetoCancelar_Click(object sender, EventArgs e)
        {
            ResetForm();
            Close();
        }

        private void btnProjetoPath_Click(object sender, EventArgs e)
        {
            textProjetoPath.Text = DialogCommon.ChooseDirectory() ?? textProjetoPath.Text;
        }
    }
}
