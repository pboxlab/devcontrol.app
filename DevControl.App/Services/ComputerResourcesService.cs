using System.Diagnostics;

namespace DevControl.App.Services
{
    public class ComputerResourcesService
    {
        private string _usedMemory = "0";
        private string _totalMemory = "0";
        private string _percentMemory = "0";

        //public string UsedMemory { get { return _usedMemory; } set { _usedMemory = value; } }
        //public string TotalMemory { get { return _totalMemory; } set { _totalMemory = value; } }



        public string Memory
        {
            get
            {
                return $"{_usedMemory.Replace("GB","").Trim()}/{_totalMemory} ({_percentMemory}%)";
            }
        }



        public ComputerResourcesService()
        {
        }

        public void GetComputerResources()
        {
            var currentProcess = Process.GetCurrentProcess();
            long processMemory = currentProcess.PrivateMemorySize64;
            long totalMemory = GetTotalMemory();
            long availableMemory = GetAvailableMemory();
            long usedMemory = totalMemory - availableMemory;

            _usedMemory = FormatBytes(usedMemory);
            _totalMemory = FormatBytes(totalMemory);

            _percentMemory = ((usedMemory * 100) / totalMemory).ToString();

            //labelMonitorMemoriaValue.Text = $"{FormatBytes(processMemory)} / {FormatBytes(availableMemory)} / {FormatBytes(usedMemory)} de {FormatBytes(totalMemory)}";
            //lblUsedMemory.Text = $"Used Memory: {FormatBytes(usedMemory)}";
            //lblAvailableMemory.Text = $"Available Memory: {FormatBytes(availableMemory)}";
            //lblProcessMemory.Text = $"Process Memory: {FormatBytes(processMemory)}";
        }

        private long GetTotalMemory()
        {
            var memoryStatus = new MEMORYSTATUSEX();
            if (GlobalMemoryStatusEx(memoryStatus))
            {
                return (long)memoryStatus.ullTotalPhys;
            }
            return 0;
        }

        private long GetAvailableMemory()
        {
            var memoryStatus = new MEMORYSTATUSEX();
            if (GlobalMemoryStatusEx(memoryStatus))
            {
                return (long)memoryStatus.ullAvailPhys;
            }
            return 0;
        }

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private class MEMORYSTATUSEX
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public ulong ullTotalPhys;
            public ulong ullAvailPhys;
            public ulong ullTotalPageFile;
            public ulong ullAvailPageFile;
            public ulong ullTotalVirtual;
            public ulong ullAvailVirtual;
            public ulong ullAvailExtendedVirtual;
            public MEMORYSTATUSEX()
            {
                this.dwLength = (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(MEMORYSTATUSEX));
            }
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        private static extern bool GlobalMemoryStatusEx([System.Runtime.InteropServices.In][System.Runtime.InteropServices.Out] MEMORYSTATUSEX lpBuffer);


        private string FormatBytes(long bytes)
        {
            string[] suffixes = { "B", "KB", "MB", "GB", "TB" };
            int counter = 0;
            double bytesD = bytes; // Convertendo para double para preservar as casas decimais

            while (bytesD >= 1024 && counter < suffixes.Length - 1)
            {
                bytesD /= 1024;
                counter++;
            }

            return $"{bytesD:0.0} {suffixes[counter]}";
        }
    }
}
