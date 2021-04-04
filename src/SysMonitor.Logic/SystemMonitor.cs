using System;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using Microsoft.EntityFrameworkCore;

namespace SysMonitor.Logic
{
    public class SystemMonitor
    {
        public MonitoringData LastRead { get; private set; }
        private readonly ISystemDataReader _dataReader;

        public SystemMonitor(ISystemDataReader systemDataReader)
        {
            _dataReader = systemDataReader;
        }

        public static SystemMonitor Create()
        {
            ISystemDataReader systemDataReader;
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32NT:
                    systemDataReader = new WindowsSystemDataReader();
                    break;
                case PlatformID.Unix:
                    systemDataReader = new LinuxSystemDataReader();
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }

            return new SystemMonitor(systemDataReader);
        }

        public MonitoringData GetData()
        {
            var monitoringData = new MonitoringData
            {
                OsName = _dataReader.GetOsName(),
                HostName = _dataReader.GetHostName(),
                IpAddress = _dataReader.GetIpAddress(),

                DiskCapacity = _dataReader.GetDiskCapacity(),
                DiskUsage = _dataReader.GetDiskUsage(),

                RamCapacity = _dataReader.GetRamCapacity(),
                RamUsage = _dataReader.GetRamUsage(),

                CpuName = _dataReader.GetCpuName(),
                CpuUsage = _dataReader.GetCpuUsage(),
            };

            LastRead = monitoringData;
            PersistData(monitoringData);

            return monitoringData;
        }

        private void PersistData(MonitoringData data)
        {
            using (var context = new SysMonitorDbContext())
            {
                // TODO: This should not be here
                context.Database.Migrate();

                context.MonitoringData.Add(data);
                context.SaveChanges();
            }
        }

        public string ExportData()
        {
            var location = Directory.GetCurrentDirectory() + "/export.csv";
            using (var context = new SysMonitorDbContext())
            using (var writer = new StreamWriter(location))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                context.Database.Migrate(); // TODO: This should not be here

                var data = context.MonitoringData.ToList();
                csv.WriteRecords(data);
            }

            return location;
        }
    }
}
