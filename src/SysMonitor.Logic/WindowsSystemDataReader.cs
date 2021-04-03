using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace SysMonitor.Logic
{
    #pragma warning disable CA1416
    public class WindowsSystemDataReader : ISystemDataReader
    {
        #region Disk

        public double GetDiskCapacity()
        {
            var drivers = DriveInfo.GetDrives();
            return drivers.First().TotalSize / 1024.0 / 1024 / 1024;
        }

        public double GetDiskUsage()
        {
            var drivers = DriveInfo.GetDrives();
            var capacity = drivers.First().TotalSize / 1024.0 / 1024 / 1024;
            var available = drivers.First().AvailableFreeSpace / 1024.0 / 1024 / 1024;
            return capacity - available;
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
            var capacity = GetRamCapacity();
            var availablePhysicalMemory = new PerformanceCounter(
                "Memory", "Available MBytes").RawValue;

            return capacity - availablePhysicalMemory;
        }

        #endregion

        #region CPU

        public string GetCpuName()
        {
            #if _WINDOWS
            var key = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0\");

            var processorName = key?.GetValue("ProcessorNameString");
            if (processorName != null)
            {
                return processorName.ToString()?.Trim() ?? string.Empty;
            }
            #endif

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
