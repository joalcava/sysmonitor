﻿using ArandaSoftware.SysMonitor.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArandaSoftware.SysMonitor
{
    static class MonitoringDataStringBuilder
    {
        private static char BulletChar = '•';

        public static string Build(MonitoringData data)
        {
            //var resources = new ComponentResourceManager(typeof(MainForm));
            var ramUsagePercentage = (data.RamUsage / data.RamCapacity) * 100;

            var stringBuilder = new StringBuilder()
                .AppendJoin(" ", BulletChar, "Operative System")
                .AppendJoin(" ", ":", data.OsName)
                .AppendLine()
                .AppendJoin(" ", BulletChar, "Machine Name")
                .AppendJoin(" ", ":", data.HostName)
                .AppendLine()
                .AppendJoin(" ", BulletChar, "IP Address")
                .AppendJoin(" ", ":", data.IpAddress)
                .AppendLine()
                .AppendJoin(" ", BulletChar, "Hard Disk")
                .AppendJoin(" ", ":", data.DiskCapacity, "/", data.DiskUsage)
                .AppendLine()
                .AppendJoin(" ", BulletChar, "RAM")
                .AppendJoin(" ", ":", data.RamCapacity, "MB", "/", ramUsagePercentage.ToString("0.##"), "%")
                .AppendLine()
                .AppendJoin(" ", BulletChar, "CPU")
                .AppendJoin(" ", ":", data.CpuName, "/", data.CpuUsage)
                .AppendLine()
                .AppendJoin(" ", BulletChar, "Report Date")
                .AppendJoin(" ", ":", data.DateCreated)
                .AppendLine();

            return stringBuilder.ToString();
        }
    }
}
