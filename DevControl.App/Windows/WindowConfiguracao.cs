using DevControl.App.Data.Repositories;
using Microsoft.Win32;

namespace DevControl.App.Windows
{
    public partial class WindowConfiguracao : Form
    {
        private bool _enableLoad = false;

        public WindowConfiguracao()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            checkFecharPrograma.Checked = AppConfig.HideProgramClosing;
            checkIniciaWindows.Checked  = AppConfig.StartWithWindows;

            if (string.IsNullOrEmpty(AppConfig.PathDatabase) || !File.Exists(AppConfig.PathDatabase))
            {
                labelBancoPath.Text = "Nenhum arquivo para o banco foi encontrato.";
            }
            else
            {
                labelBancoPath.Text = AppConfig.PathDatabase;
            }

            _enableLoad = true;
        }

        private void WindowConfiguracoes_FormClosed(object sender, FormClosingEventArgs e)
        {
            if (!AppConfig.ProgramConfigured)
            {
                e.Cancel = true;
                MessageBox.Show($"Você deve salvar as configurações obrigatórias.", "Configurações", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void SetValueConfig(string key, string value)
        {
            if (!_enableLoad)
                return;

            AppConfig.SetRegKey(key, value);
        }

        private void checkFecharPrograma_CheckedChanged(object sender, EventArgs e)
        {
            SetValueConfig("HideProgramClosing", (checkFecharPrograma.Checked ? "true" : "false"));
        }

        private void SetStartup(bool enable)
        {
            string appName = AppConfig.AppName;
            string appPath = Application.ExecutablePath;

            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

            if (enable)
            {
                registryKey.SetValue(appName, $"\"{appPath}\" /background");
            }
            else
            {
                registryKey.DeleteValue(appName, false);
            }
        }

        private void checkIniciaWindows_CheckedChanged(object sender, EventArgs e)
        {
            if (!_enableLoad)
                return;

            SetStartup(checkIniciaWindows.Checked);
            SetValueConfig("StartWithWindows", (checkIniciaWindows.Checked ? "true" : "false"));
        }

        private void btnBancoExistente_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "SQLite|*.db";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var pathDB = openFileDialog.FileName;
                var extension = Path.GetExtension(pathDB);

                if (string.IsNullOrEmpty(pathDB) || !File.Exists(pathDB) || extension != ".db")
                {
                    labelBancoPath.Text = "O Arquivo é inválido";
                    MessageBox.Show("Arquivo selecionado é inválido.\nSelecione um arquivo SQLite (.db)", "Arquivo inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    labelBancoPath.Text = pathDB;

                    SetValueConfig("PathDatabase", pathDB);
                    SetValueConfig("ProgramConfigured", "true");

                    MessageBox.Show("O banco de dados foi configurado!", "Banco configurado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private async void btnNovoBanco_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    var createObjects = await CreateNewDatabase(folderBrowserDialog.SelectedPath);

                    if (!string.IsNullOrEmpty(createObjects))
                    {
                        labelBancoPath.Text = createObjects;

                        SetValueConfig("PathDatabase", createObjects);
                        SetValueConfig("ProgramConfigured", "true");

                        MessageBox.Show("O banco de dados foi configurado!", "Banco configurado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private async Task<string?> CreateNewDatabase(string selectedPath)
        {
            string fileExtension = ".db";
            string databaseName = "DevControlApp";
            string databasePath = Path.Combine(selectedPath, $"{databaseName}{fileExtension}");
            int counter = 1;

            while (File.Exists(databasePath))
            {
                databasePath = Path.Combine(selectedPath, $"{databaseName}_{counter}{fileExtension}");
                counter++;
            }

            DataBaseRepository dataBaseRepository = new(databasePath);

            var createDataBase = dataBaseRepository.CreateDataBase();

            if(createDataBase != "true")
            {
                MessageBox.Show($"Erro ao criar o banco de dados!\nErro: {createDataBase}", "Erro ao criar banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            var createObjects = await dataBaseRepository.CreateObjectsAsync();

            if (createObjects != "true")
            {
                MessageBox.Show($"Erro ao criar os objetos do banco!\nErro: {createObjects}", "Erro ao criar objetos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return databasePath;
        }

    }
}
