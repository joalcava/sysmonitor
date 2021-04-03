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
            PersistData(monitoringData);
            
            return monitoringData;
        }

        private void PersistData(MonitoringData data)
        {
            using (var context = new SysMonitorDbContext())
            {
                context.MonitoringData.Add(data);
                context.SaveChanges();
            }
        }

    }
}
