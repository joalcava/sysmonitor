using System;

namespace ArandaSoftware.SysMonitor.Logic
{
    public class MonitoringData
    {
        public MonitoringData()
        {
            Date = DateTimeOffset.Now;
        }

        public string OsName { get; set; }
        public string HostName { get; set; }
        public string IpAddress { get; set; }

        public long DiskCapacity { get; set; }
        public long DiskUsage { get; set; }

        public long RamCapacity { get; set; }
        public long RamUsage { get; set; }

        public string CpuName { get; set; }
        public long CpuUsage { get; set; }

        public readonly DateTimeOffset Date;
    }
}
