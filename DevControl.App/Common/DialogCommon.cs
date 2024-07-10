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

        public static void OpenDirectoryClick(string path)
        {
            if (Directory.Exists(path))
            {
                Process.Start("explorer.exe", path);
            }
            else
            {
                MessageBox.Show("Diretório não encontrado", "Diretório não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
