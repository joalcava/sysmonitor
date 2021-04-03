using System;
using System.Text;
using SysMonitor.Logic;

namespace SysMonitor.Console
{
    static class MonitoringDataStringBuilder
    {
        private static char BulletChar = '•';

        public static string Build(MonitoringData data)
        {
            var ramUsage = (data.RamUsage / data.RamCapacity) * 100;
            var diskUsage = (data.DiskUsage / data.DiskCapacity) * 100;

            var stringBuilder = new StringBuilder()
                .AppendJoin(" ", BulletChar, "Operative System:", data.OsName)
                .AppendLine()
                .AppendJoin(" ", BulletChar, "Machine Name:", data.HostName)
                .AppendLine()
                .AppendJoin(" ", BulletChar, "IP Address:", data.IpAddress)
                .AppendLine()
                .AppendJoin(" ", BulletChar, "Hard Disk: ")
                .AppendJoin(" ", data.DiskCapacity.ToString("0.##"), "GB", "/", FormatPercentage(diskUsage))
                .AppendLine()
                .AppendJoin(" ", BulletChar, "RAM: ")
                .AppendJoin(" ", data.RamCapacity.ToString("0.##"), "MB", "/", FormatPercentage(ramUsage))
                .AppendLine()
                .AppendJoin(" ", BulletChar, "CPU: ")
                .AppendJoin(" ", data.CpuName, "/", FormatPercentage(data.CpuUsage))
                .AppendLine()
                .AppendJoin(" ", BulletChar, "Report Date:", data.DateCreated)
                .AppendLine();

            return stringBuilder.ToString();
        }

        private static string FormatPercentage(double value) => value.ToString("0.##") + "%";
    }
}
