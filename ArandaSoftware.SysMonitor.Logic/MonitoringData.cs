using System;

namespace ArandaSoftware.SysMonitor.Logic
{
    public class MonitoringData
    {
        public MonitoringData()
        {
            DateCreated = DateTimeOffset.Now;
        }

        public long Id { get; set; }

        public string OsName { get; set; }
        public string HostName { get; set; }
        public string IpAddress { get; set; }

        public double DiskCapacity { get; set; }
        public double DiskUsage { get; set; }

        public double RamCapacity { get; set; }
        public double RamUsage { get; set; }

        public string CpuName { get; set; }
        public double CpuUsage { get; set; }

        public readonly DateTimeOffset DateCreated;
    }
}
