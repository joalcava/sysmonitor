using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace ArandaSoftware.SysMonitor.Logic
{
    public class UnixSystemDataReader : ISystemDataReader
    {

        #region Info

        public string GetHostName()
        {
            return Environment.MachineName;
        }

        public string GetIpAddress()
        {
            var addresses = System.Net.Dns.GetHostAddresses(GetHostName());
            var ipv4 = addresses.FirstOrDefault(
                x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);

            return ipv4 != null ? ipv4.ToString() : string.Empty;
        }

        public string GetOsName()
        {
            return Environment.OSVersion.ToString();
        }

        #endregion

        #region Disk

        public double GetDiskCapacity() => 0;

        public double GetDiskUsage() => 0;

        #endregion

        # region RAM

        public double GetRamCapacity()
        {
            var valueBytes = new PerformanceCounter("Mono Memory", "Total Physical Memory")
                .RawValue;

            return valueBytes / 1024.0 / 1024.0;
        }

        public double GetRamUsage()
        {
            var valueBytes = new PerformanceCounter("Mono Memory", "Available Physical Memory")
                .RawValue;
            Console.WriteLine(valueBytes);

            return valueBytes / 1024.0 / 1024.0;
        }

        #endregion

        #region CPU

        public string GetCpuName()
        {
            return string.Empty;
        }

        public float GetCpuUsage()
        {
            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuCounter.NextValue();
            Thread.Sleep(500);
            return cpuCounter.NextValue();
        }

        #endregion
    }
}