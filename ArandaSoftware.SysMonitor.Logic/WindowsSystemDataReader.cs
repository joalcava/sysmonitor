using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArandaSoftware.SysMonitor.Logic
{
    public class WindowsSystemDataReader : ISystemDataReader
    {
        #region Disk

        public double GetDiskCapacity()
        {
            return 0;
        }

        public double GetDiskUsage()
        {
            return 0;
        }

        #endregion

        #region RAM

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetPhysicallyInstalledSystemMemory(out long totalMemoryInKilobytes);

        public double GetRamCapacity()
        {
            long memKb;
            GetPhysicallyInstalledSystemMemory(out memKb);

            return memKb / 1024.0;
        }

        public double GetRamUsage()
        {
            var availablePhysicalMemory = new PerformanceCounter(
                "Memory", "Available MBytes").RawValue;

            return availablePhysicalMemory;
        }

        #endregion

        #region CPU

        public string GetCpuName()
        {
            return string.Empty;
        }

        public double GetCpuUsage()
        {
            return 0;
        }

        #endregion

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
    }
}
