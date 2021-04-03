using System;
using System.Diagnostics;
using System.Linq;

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

        public double GetRamCapacity() =>
            new PerformanceCounter("Mono Memory", "Total Physical Memory").RawValue;

        public double GetRamUsage() => throw new System.NotImplementedException();

        #endregion

        #region CPU

        public string GetCpuName() => string.Empty;

        public float GetCpuUsage() => 0;

        #endregion
    }
}