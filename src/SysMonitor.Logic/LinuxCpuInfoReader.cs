using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SysMonitor.Logic
{
    /// <summary>
    /// Reads /proc/cpuinfo
    /// </summary>
    public class LinuxCpuInfoReader
    {
        public string VendorId { get; private set; }
        public int CpuFamily { get; private set; }
        public int Model { get; private set; }
        public string ModelName { get; private set; }

        public void LoadValues()
        {
            string[] cpuInfoLines = File.ReadAllLines(@"/proc/cpuinfo");

            CpuInfoMatch[] cpuInfoMatches =
            {
                new CpuInfoMatch(@"^vendor_id\s+:\s+(.+)", value => VendorId = Convert.ToString(value)),
                new CpuInfoMatch(@"^cpu family\s+:\s+(.+)", value => CpuFamily = Convert.ToInt32(value)),
                new CpuInfoMatch(@"^model\s+:\s+(.+)", value => Model = Convert.ToInt32(value)),
                new CpuInfoMatch(@"^model name\s+:\s+(.+)", value => ModelName = Convert.ToString(value)),
            };

            foreach (string cpuInfoLine in cpuInfoLines)
            {
                foreach (CpuInfoMatch cpuInfoMatch in cpuInfoMatches)
                {
                    var match = cpuInfoMatch.Regex.Match(cpuInfoLine);
                    if (match.Groups[0].Success)
                    {
                        var value = match.Groups[1].Value;
                        cpuInfoMatch.UpdateValue(value);
                    }
                }
            }
        }

        private class CpuInfoMatch
        {
            public readonly Regex Regex;
            public readonly Action<string> UpdateValue;

            public CpuInfoMatch(string pattern, Action<string> update)
            {
                Regex = new Regex(pattern, RegexOptions.Compiled);
                UpdateValue = update;
            }
        }
    }
}