using SysMonitor.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SysMonitor.WinForms
{
    static class MonitoringDataStringBuilder
    {
        private static char BulletChar = '•';

        public static string Build(MonitoringData data)
        {
            var res = new ComponentResourceManager(typeof(MainForm));
            var ramUsagePercentage = (data.RamUsage / data.RamCapacity) * 100;
            var diskUsagePercentage = (data.DiskUsage / data.DiskCapacity) * 100;

            var stringBuilder = new StringBuilder()
                .AppendJoin(" ", BulletChar, res.GetString("OperativeSystem"))
                .AppendJoin(" ", ":", data.OsName)
                .AppendLine()
                .AppendJoin(" ", BulletChar, res.GetString("MachineName"))
                .AppendJoin(" ", ":", data.HostName)
                .AppendLine()
                .AppendJoin(" ", BulletChar, res.GetString("IpAddress"))
                .AppendJoin(" ", ":", data.IpAddress)
                .AppendLine()
                .AppendJoin(" ", BulletChar, res.GetString("Disk"))
                .AppendJoin(" ", ":", data.DiskCapacity.ToString("0.##"), "GB", "/", diskUsagePercentage.ToString("0.##"), "%")
                .AppendLine()
                .AppendJoin(" ", BulletChar, res.GetString("Ram"))
                .AppendJoin(" ", ":", data.RamCapacity.ToString("0.##"), "MB", "/", ramUsagePercentage.ToString("0.##"), "%")
                .AppendLine()
                .AppendJoin(" ", BulletChar, res.GetString("CPU"))
                .AppendJoin(" ", ":", data.CpuName, "/", data.CpuUsage.ToString("0.##"), "%")
                .AppendLine()
                .AppendJoin(" ", BulletChar, res.GetString("Date"))
                .AppendJoin(" ", ":", data.DateCreated)
                .AppendLine();

            return stringBuilder.ToString();
        }
    }
}
