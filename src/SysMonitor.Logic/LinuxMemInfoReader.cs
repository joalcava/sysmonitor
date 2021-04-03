using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SysMonitor.Logic
{
    /// <summary>
    /// Reads /proc/meminfo
    /// </summary>
    public class LinuxMemInfoReader
    {
        public double MemTotal { get; private set; }
        public double MemFree { get; private set; }
        public double MemAvailable { get; private set; }

        public void LoadValues()
        {
            string[] cpuInfoLines = File.ReadAllLines(@"/proc/meminfo");

            CpuInfoMatch[] cpuInfoMatches =
            {
                new CpuInfoMatch(@"^MemTotal:\s+(\d+)", value => MemTotal = Convert.ToDouble(value)),
                new CpuInfoMatch(@"^MemFree:\s+(\d+)", value => MemFree = Convert.ToDouble(value)),
                new CpuInfoMatch(@"^MemAvailable:\s+(\d+)", value => MemAvailable = Convert.ToDouble(value)),
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