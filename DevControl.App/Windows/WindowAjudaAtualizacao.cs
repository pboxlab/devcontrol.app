using Octokit;
using System.Diagnostics;
using System.Net;

namespace DevControl.App.Windows
{
    public partial class WindowAjudaAtualizacao : Form
    {
        private bool   _startDownload      = false;
        private string _repositoryVersion  = "";
        private string _currentVersion     = AppConfig.VersionProgram;

        public WindowAjudaAtualizacao(bool check)
        {
           
        }

        public WindowAjudaAtualizacao()
        {
            InitializeComponent();

            labelTitle.Text   = $"Verificando a versão mais recente...";
            labelVersion.Text = $"";
            labelMessage.Text = $"";
            btnFechar.Visible = false;
            btnUpdate.Visible = false;

            CheckVersion();
        }

        public async Task<bool> HaveNewerVersion()
        {
            var client   = new GitHubClient(new ProductHeaderValue("MyApp"));
            var releases = await client.Repository.Release.GetAll("pboxlab", "devcontrol.app");

            if (releases.Count > 0)
            {
                _repositoryVersion        = releases[0].TagName;

                Version currentVersion    = new(_currentVersion);
                Version repositoryVersion = new(_repositoryVersion);

                int comparisonResult      = currentVersion.CompareTo(repositoryVersion);

                return (comparisonResult < 0);
            }
            else
            {
                return false;
            }
        }

        private async void CheckVersion()
        {
            var isNewVersion      = await HaveNewerVersion();
                                  
            labelTitle.Text       = AppConfig.AppName;
            labelVersion.Text     = $"Sua versão atual: {AppConfig.VersionProgram}";

            if (isNewVersion)
            {
                labelMessage.Text = $"A nova versão {_repositoryVersion} do {AppConfig.AppName} já está disponível!";
                btnUpdate.Text    = $"Atualizar para {_repositoryVersion}";
                btnUpdate.Visible = true;
            }
            else
            {
                labelMessage.Text = $"Você já está usando a versão mais recente, não há novas atualizações disponíveis no momento.";
                btnFechar.Visible = true;
            }
        }

        private void btnSobreAtualizacaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            _startDownload = true;
            labelMessage.Text = $"Iniciando download, aguarde...";
            btnUpdate.Visible = false;

            string url = $"https://github.com/pboxlab/devcontrol.app/releases/download/{_repositoryVersion}/DevControlApp-{_repositoryVersion}-Setup.exe";
            string fileName = $"DevControlApp-{_repositoryVersion}-Setup.exe";

            string tempPath = Path.GetTempPath();
            string filePath = Path.Combine(tempPath, fileName);

            using (WebClient webClient = new())
            {
                webClient.DownloadProgressChanged += (s, e) =>
                {
                    labelMessage.Text = $"Download: {e.ProgressPercentage}%";
                };

                webClient.DownloadFileCompleted += (s, e) =>
                {
                    if (e.Error != null)
                    {
                        labelMessage.Text = $"Ocorreu um erro durante o download: {e.Error.Message}";
                        _startDownload = false;
                    }
                    else
                    {
                        labelMessage.Text ="Download concluído.";
                        ExecuteInstaller(filePath);
                    }
                };

                try
                {
                    labelMessage.Text ="Baixando atualização...";
                    await webClient.DownloadFileTaskAsync(new Uri(url), filePath);
                }
                catch (Exception ex)
                {
                    labelMessage.Text =$"Ocorreu um erro durante o download: {ex.Message}";
                    _startDownload = false;
                }
            }
        }

        private void ExecuteInstaller(string filePath)
        {
            try
            {
                labelMessage.Text = "Iniciando instalador...";
                Process.Start(filePath);
                labelMessage.Text = "Instalador executado.";
                _startDownload = false;
            }
            catch (Exception ex)
            {
                labelMessage.Text = $"Ocorreu um erro ao executar o instalador: {ex.Message}";
                _startDownload = false;
            }
        }

        private void WindowAjudaAtualizacao_FormClosed(object sender, FormClosingEventArgs e)
        {
            if (_startDownload)
            {
                e.Cancel = true;
                MessageBox.Show($"Atualização ainda não concluída", "Aguarde", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
