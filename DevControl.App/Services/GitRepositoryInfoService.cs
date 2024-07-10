using LibGit2Sharp;

namespace DevControl.App.Services
{
    public class GitRepositoryInfoService
    {
        private readonly string _rootDirectory;
        private string _remoteUrl;
        private string _currentBranch;

        public string RemoteUrl { get { return _remoteUrl; } set { _remoteUrl = value; } }
        public string CurrentBranch { get { return _currentBranch; } set { _currentBranch = value; } }

        public GitRepositoryInfoService(string rootDirectory)
        {
            _rootDirectory = rootDirectory;

            GeInfo();


        }


        private void GeInfo()
        {
            try
            {
                using (var repo = new Repository(_rootDirectory))
                {
                    var remote = repo.Network.Remotes["origin"];
                    var url = remote?.Url ?? "No remote URL found";
                    var branch = repo.Head.FriendlyName;

                    _remoteUrl = url;
                    _currentBranch = branch;

                    Console.WriteLine($"Git repository found in: {_rootDirectory}");
                    Console.WriteLine($"Remote URL: {url}");
                    Console.WriteLine($"Current branch: {branch}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing Git repository in: {_rootDirectory}. Error: {ex.Message}");
            }
        }



    }
}
