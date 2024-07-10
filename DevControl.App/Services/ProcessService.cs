using System.Diagnostics;
using System.Net.NetworkInformation;

namespace DevControl.App.Services
{
    public class ProcessService
    {
        public bool IsProcessRunning(string processName)
        {
            return Process.GetProcessesByName(processName).Any();
        }

        public bool IsPortInUse(int port)
        {
            var ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            var tcpConnections = ipGlobalProperties.GetActiveTcpConnections();
            var tcpListeners = ipGlobalProperties.GetActiveTcpListeners();
            var udpListeners = ipGlobalProperties.GetActiveUdpListeners();

            return tcpConnections.Any(tc => tc.LocalEndPoint.Port == port) ||
                   tcpListeners.Any(tc => tc.Port == port) ||
                   udpListeners.Any(uc => uc.Port == port);
        }

        public Process GetProcessUsingPort(int port)
        {
            try
            {
                string netstatOutput = RunNetstatCommand();
                int pid = ParseNetstatOutputForPort(netstatOutput, port);

                if (pid != -1)
                {
                    return Process.GetProcessById(pid);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter o processo: {ex.Message}");
            }

            return null;
        }

        public string RunNetstatCommand()
        {
            using (Process netstat = new Process())
            {
                netstat.StartInfo.FileName = "netstat";
                netstat.StartInfo.Arguments = "-a -n -o";
                netstat.StartInfo.RedirectStandardOutput = true;
                netstat.StartInfo.UseShellExecute = false;
                netstat.StartInfo.CreateNoWindow = true;
                netstat.Start();

                return netstat.StandardOutput.ReadToEnd();
            }
        }

        public int ParseNetstatOutputForPort(string netstatOutput, int port)
        {
            string[] lines = netstatOutput.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                if (line.Contains($":{port}"))
                {
                    string[] tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (tokens.Length > 4)
                    {
                        int pid;
                        if (int.TryParse(tokens[tokens.Length - 1], out pid))
                        {
                            return pid;
                        }
                    }
                }
            }

            return -1;
        }

    }
}
