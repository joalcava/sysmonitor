using System;
using System.Diagnostics;
using System.IO;
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

        # region RAM

        public double GetRamCapacity()
        {
            var valueBytes = new PerformanceCounter("Mono Memory", "Total Physical Memory")
                .RawValue;

            return valueBytes / 1024.0 / 1024.0;
        }

        public double GetRamUsage()
        {
            var capacity = GetRamCapacity();
            var valueBytes = new PerformanceCounter(
                "Mono Memory", "Available Physical Memory").RawValue;
            
            return capacity - (valueBytes / 1024.0 / 1024.0);
        }

        #endregion

        #region CPU

        public string GetCpuName()
        {
            var cat = PerformanceCounterCategory.GetCategories();
            foreach (var category in cat)
            {
                Console.WriteLine(category.CategoryName); 
                var counters = category.GetCounters();
                foreach (var counter in counters)
                {
                    Console.WriteLine(counter.CounterName); 
                }
            }
            
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