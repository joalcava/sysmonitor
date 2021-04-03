using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysMonitor.Logic
{
    public interface ISystemDataReader
    {

        string GetHostName();
        string GetIpAddress();
        string GetOsName();


        double GetDiskCapacity();
        double GetDiskUsage();

        double GetRamCapacity();
        double GetRamUsage();

        string GetCpuName();
        float GetCpuUsage();
    }
}
