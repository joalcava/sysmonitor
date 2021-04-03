using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace SysMonitor.Logic
{
    public class UnixSystemDataReader : ISystemDataReader
    {
        private readonly LinuxMemInfoReader _memInfoReaderReader;
        private readonly LinuxCpuInfoReader _cpuInfoReaderReader;
        private readonly DriveInfo[] _drivers;

        public UnixSystemDataReader()
        {
            _drivers = DriveInfo.GetDrives();
            _memInfoReaderReader = new LinuxMemInfoReader();
            _cpuInfoReaderReader = new LinuxCpuInfoReader();

            _cpuInfoReaderReader.LoadValues();
            _memInfoReaderReader.LoadValues();
        }

        #region Info

        public string GetHostName() => Environment.MachineName;

        public string GetIpAddress()
        {
            var addresses = System.Net.Dns.GetHostAddresses(GetHostName());
            var ipv4 = addresses.FirstOrDefault(
                x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);

            return ipv4 != null ? ipv4.ToString() : string.Empty;
        }

        public string GetOsName() =>
            // Environment.OsVersion does not return good info on WSL, so use System.Runtime
            System.Runtime.InteropServices.RuntimeInformation.OSDescription;

        #endregion

        #region Disk

        public double GetDiskCapacity() => _drivers.First().TotalSize / 1024.0 / 1024 / 1024;

        public double GetDiskUsage()
        {
            var capacity = _drivers.First().TotalSize / 1024.0 / 1024 / 1024;
            var available = _drivers.First().AvailableFreeSpace / 1024.0 / 1024 / 1024;
            return capacity - available;
        }

        #endregion

        # region RAM

        public double GetRamCapacity()
        {
            return _memInfoReaderReader.MemTotal / 1024.0;
        }

        public double GetRamUsage()
        {
            var capacity = _memInfoReaderReader.MemTotal;
            var available = _memInfoReaderReader.MemAvailable;

            return (capacity - available) / 1024.0;
        }

        #endregion

        #region CPU

        public string GetCpuName() => _cpuInfoReaderReader.ModelName ?? string.Empty;

        public float GetCpuUsage()
        {
            var cpuUsageStr = "top -b -d1 -n1|grep -i \"Cpu(s)\"|head -c21|cut -d ' ' -f3|cut -d '%' -f1".Bash();
            var cpuUsage = Convert.ToDouble(cpuUsageStr);
            return (float)cpuUsage;
        }

        #endregion
    }
}