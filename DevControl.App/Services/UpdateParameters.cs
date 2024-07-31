using Microsoft.Win32;
using System.Reflection;

namespace DevControl.App.Services
{
    internal class UpdateParameters
    {
        private static string _appName;
        private static string _companyName;

        public UpdateParameters()
        {
            GetAssemblyValue();
        }

        private void GetAssemblyValue()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            AssemblyCompanyAttribute companyAttribute = (AssemblyCompanyAttribute)assembly
                .GetCustomAttributes(typeof(AssemblyCompanyAttribute), false)
                .FirstOrDefault();

            _appName     = assembly.GetName().Name!;
            _companyName = companyAttribute?.Company ?? "PBOX Lab";
        }

        internal void CheckParameters()
        {
            var registryPath = @$"Software\{_companyName}\{_appName}";
            var parameters   = new List<(string Name, string Value)>
            {
                ("ProgramConfigured", "false"),
                ("PathDatabase", ""),
                ("StartWithWindows", "false"),
                ("HideProgramClosing", "true")
            };

            try
            {
                using var keyValue = Registry.CurrentUser.CreateSubKey(registryPath);
                foreach (var parameter in parameters)
                {
                    if (keyValue.GetValue(parameter.Name) == null)
                    {
                        keyValue.SetValue(parameter.Name, parameter.Value);
                    }
                }
                keyValue.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível criar os registros no Windows.\nMensagem: {ex.Message}");
                return;
            }
        }
    }
}
