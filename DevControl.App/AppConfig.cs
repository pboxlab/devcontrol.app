using Microsoft.Win32;
using System.Reflection;

namespace DevControl.App
{
    public class AppConfig
    {
        private static bool?  _hideProgramClosing;
        private static bool?  _programConfigured;
        private static bool?  _startWithWindows;

        private static string _appName = GetAssemblyName();
        private static string _companyName = GetAssemblyCompany();

        private static string GetAssemblyName()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetName().Name ?? "DevControl App";
        }
        private static string GetAssemblyCompany()
        {
            var assembly         = Assembly.GetExecutingAssembly();
            var companyAttribute = (AssemblyCompanyAttribute)assembly
                .GetCustomAttributes(typeof(AssemblyCompanyAttribute), false)
                .FirstOrDefault()!;
            return companyAttribute?.Company ?? "PBOX Lab";
        }

        private static string GetRegKey(string regName)
        {
            var registryPath = @$"Software\{_companyName}\{_appName}";
            var registry = Registry.CurrentUser.OpenSubKey(registryPath);
            var value = (registry.GetValue(regName) ?? "").ToString();
            registry.Close();
            return value;
        }

        public static string SetRegKey(string name, string value)
        {
            var registryPath = @$"Software\{_companyName}\{_appName}";
            var registry = Registry.CurrentUser.CreateSubKey(registryPath);

            registry.SetValue(name, value);
            registry.Close();
            return value;
        }

        public static bool HideProgramClosing
        {
            get
            {
                if (_hideProgramClosing != null)
                {
                    return _hideProgramClosing ?? true;
                }

                return GetRegKey("HideProgramClosing") == "true";
            }

            set => _hideProgramClosing = value;
        }

        public static bool ProgramConfigured
        {
            get
            {
                if (_programConfigured != null)
                {
                    return _programConfigured ?? true;
                }

                return GetRegKey("ProgramConfigured") == "true";
            }

            set => _programConfigured = value;
        }

        public static bool StartWithWindows
        {
            get
            {
                if (_startWithWindows != null)
                {
                    return _startWithWindows ?? true;
                }

                return GetRegKey("StartWithWindows") == "true";
            }

            set => _startWithWindows = value;
        }

        public static string VersionProgram
        {
            get
            {
                Version version = Assembly.GetExecutingAssembly().GetName().Version!;
                return $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
            }
        }

        public static string PathDatabase
        {
            get => GetRegKey("PathDatabase");
        }

        public static string AppName
        {
            get
            {
                return _appName;
            }
        }
    }
}
