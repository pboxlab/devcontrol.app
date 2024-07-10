using System.Diagnostics;

namespace DevControl.App.Windows
{
    public partial class WindowAjudaSobre : Form
    {
        public WindowAjudaSobre()
        {
            InitializeComponent();
            labelProgramVersion.Text = $"Versão {AppConfig.VersionProgram}";
        }

        private void labelLinkProjeto_Click(object sender, EventArgs e)
        {
            string url = "https://devcontrol.app";
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open URL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WindowAjudaSobre_Load(object sender, EventArgs e)
        {
            Close();
        }
    }
}
