using System;
using SysMonitor.Logic;

namespace SysMonitor.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var prevPrint = string.Empty;
            var systemMonitor = BuildSystemMonitor();

            while (true)
            {
                PrintMenu(prevPrint);

                var key = System.Console.ReadKey();
                if (key.KeyChar == '1')
                {
                    var data = systemMonitor.GetData();
                    prevPrint = MonitoringDataStringBuilder.Build(data);
                }
                else if (key.KeyChar == '2')
                {
                    var file = systemMonitor.ExportData();
                    prevPrint = "Data Exported to: " + file + Environment.NewLine;
                }
                else if (key.KeyChar == '3')
                {
                    break;
                }
            }
        }

        private static SystemMonitor BuildSystemMonitor()
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

        private static void PrintMenu(string prevPrint)
        {
            System.Console.Clear();

            System.Console.WriteLine(prevPrint);

            System.Console.WriteLine(
                "This application allows you to capture the relevant" +
                " information of the current computer (operating system, machine name, IP" +
                " address, hard disk, RAM and processor)");

            System.Console.WriteLine("---");
            System.Console.WriteLine("1) Press 1 to gather data");
            System.Console.WriteLine("2) Press 2 to export data");
            System.Console.WriteLine("3) Press 3 to exit");
        }
    }
}