using Octokit;
using System.Diagnostics;

namespace DevControl.App.Common
{
    public static class DialogCommon
    {
        public static string ChooseDirectory(string? path = null)
        {
            using FolderBrowserDialog dialog = new();

            dialog.Description = "Selecione o diretório";
            dialog.ShowNewFolderButton = true;
            dialog.InitialDirectory = path;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.SelectedPath;
            }
            return "";
        }

        public static void OpenPathClick(string workingDirectory, string fileName = "explorer.exe", string arguments = "")
        {
            try
            {
                if (!string.IsNullOrEmpty(workingDirectory) && fileName == "explorer.exe" && (Directory.Exists(workingDirectory) || File.Exists(workingDirectory)))
                {
                    Process.Start(fileName, workingDirectory);
                    return;
                }
                else if (!string.IsNullOrEmpty(workingDirectory) && fileName == "browser")
                {
                    Process.Start(new ProcessStartInfo(workingDirectory) { UseShellExecute = true });
                    return;
                }

                var process = new Process
                {
                    StartInfo = new ProcessStartInfo(fileName, arguments)
                    {
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        WorkingDirectory = workingDirectory,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    }
                };
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar abrir o caminho\n\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
