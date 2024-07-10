using System.Configuration;
using System.Reflection;

namespace DevControl.App
{
    public class AppConfig
    {
        private static bool? _hideProgramClosing;
        private static bool? _programConfigured;
        private static bool? _startWithWindows;

        public static bool HideProgramClosing
        {
            get
            {
                if (_hideProgramClosing != null)
                {
                    return _hideProgramClosing ?? true;
                }

                return ConfigurationManager.AppSettings["hide_program_closing"] == null || ConfigurationManager.AppSettings["hide_program_closing"] == "true";
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

                return ConfigurationManager.AppSettings["program_configured"] == null || ConfigurationManager.AppSettings["program_configured"] == "true";
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

                return ConfigurationManager.AppSettings["start_with_windows"] == null || ConfigurationManager.AppSettings["start_with_windows"] == "true";
            }

            set => _startWithWindows = value;
        }

        public static string VersionProgram
        {
            get
            {
                Version version = Assembly.GetExecutingAssembly().GetName().Version;
                return $"{version.Major}.{version.Minor}.{version.Build}";
            }
        }

        public static string PathDatabase
        {
            get => ConfigurationManager.AppSettings["path_database"];
        }

        public static string AppName
        {
            get => ConfigurationManager.AppSettings["app_name"];
        }
    }
}
