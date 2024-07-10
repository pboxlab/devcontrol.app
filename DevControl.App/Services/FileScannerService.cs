using System.IO;
using System.Text.RegularExpressions;

namespace DevControl.App.Services
{
    public class FileScannerService
    {
        public string RootDirectory { get; set; }

        public FileScannerService(string rootDirectory)
        {
            RootDirectory = rootDirectory;


            string gitignorePath = Path.Combine(rootDirectory, ".gitignore");
            if (File.Exists(gitignorePath))
            {
                _ignorePatterns = File.ReadAllLines(gitignorePath)
                    .Where(line => !string.IsNullOrWhiteSpace(line) && !line.StartsWith("#")) // Ignorar linhas vazias e comentários
                    .Select(line => ConvertToRegex(line))
                    .ToList();
                _ignorePatterns.Add(ConvertToRegex("/.git"));
            }
        }

        public List<string> FindProjectFiles(string type)
        {
            List<string> projectFiles = new List<string>();
            ScanDirectory(RootDirectory, projectFiles, type);
            return projectFiles;
        }

        private List<Regex> _ignorePatterns = new List<Regex>(); // Armazenar as regras de ignorar como expressões regulares

        private bool ShouldIgnore(string path)
        {
            return _ignorePatterns.Any(pattern => pattern.IsMatch(path));
        }

        private Regex ConvertToRegex(string pattern)
        {
            // Converter o padrão .gitignore em uma expressão regular (lógica simplificada)
            pattern = pattern.Replace(".", "\\.").Replace("*", ".*").Replace("?", ".");
            return new Regex(pattern, RegexOptions.IgnoreCase);
        }

        private void ScanDirectory(string directory, List<string> projectFiles, string type)
        {
            try
            {
                foreach (var file in Directory.GetFiles(directory, type))
                {
                    if (!ShouldIgnore(file))
                        projectFiles.Add(file);
                }

                foreach (var subDirectory in Directory.GetDirectories(directory))
                {
                    if (!ShouldIgnore(subDirectory))
                        ScanDirectory(subDirectory, projectFiles, type);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access denied to directory: {directory}. Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error scanning directory: {directory}. Error: {ex.Message}");
            }
        }
    }
}
