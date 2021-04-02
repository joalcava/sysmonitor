using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArandaSoftware.SysMonitor.Logic
{
    public class SystemMonitor
    {
        public MonitoringData LastRead { get; private set; }
        private readonly ISystemDataReader dataReader;

        public SystemMonitor(ISystemDataReader systemDataReader)
        {
            dataReader = systemDataReader;
        }

        public MonitoringData GetData()
        {
            var monitoringData = new MonitoringData
            {
                OsName = dataReader.GetOsName(),
                HostName = dataReader.GetHostName(),
                IpAddress = dataReader.GetIpAddress(),

                DiskCapacity = dataReader.GetDiskCapacity(),
                DiskUsage = dataReader.GetDiskUsage(),
    
                RamCapacity = dataReader.GetRamCapacity(),
                RamUsage = dataReader.GetRamUsage(),

                CpuName = dataReader.GetCpuName(),
                CpuUsage = dataReader.GetCpuUsage(),
            };

            LastRead = monitoringData;
            return monitoringData;
        }

    }
}
