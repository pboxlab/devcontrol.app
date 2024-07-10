using DevControl.App.Windows;

namespace DevControl.App
{
    internal static class Program
    {
        private static readonly string mutexName = "AppDevControl";

        [STAThread]
        static void Main(string[] args)
        {
            using Mutex mutex = new(false, mutexName, out bool createdNew);
            if (!createdNew)
            {
                MessageBox.Show($"O {AppConfig.AppName} já está em execução!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new WindowMain());
        }
    }
}