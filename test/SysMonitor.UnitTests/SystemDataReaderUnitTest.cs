using System;
using FluentAssertions;
using SysMonitor.Logic;
using Xunit;

namespace SysMonitor.UnitTests
{
    public class SystemDataReaderUnitTest
    {
        private ISystemDataReader GetPlatformDataReader()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                return new WindowsSystemDataReader();
            }
            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                return new LinuxSystemDataReader();
            }

            throw new PlatformNotSupportedException();
        }
        
        [Fact]
        public void Should_read_ip_address()
        {
            var reader = GetPlatformDataReader();
            var ip = reader.GetIpAddress();
            
            ip.Should().NotBeNullOrEmpty();
            var ipParts = ip.Split('.');
            ipParts.Length.Should().Be(4);
        }

        [Fact]
        public void HostName_should_not_be_null()
        {
            var reader = GetPlatformDataReader();
            var hostname = reader.GetHostName();

            hostname.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void Os_should_be_windows_or_linux()
        {
            var reader = GetPlatformDataReader();
            var os = reader.GetOsName();

            os.ToLower().Should().ContainAny("windows", "linux", "unix", "wsl");
        }

        [Fact]
        public void CPU_usage_should_be_more_than_0()
        {
            // TODO: Maybe this is not very reliable 
            var reader = GetPlatformDataReader();
            var cpuUsage = reader.GetCpuUsage();
            cpuUsage.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Cpu_name_should_be_intel_or_amd()
        {
            var reader = GetPlatformDataReader();
            var cpuName = reader.GetCpuName();
            
            cpuName.ToLower().Should().ContainAny("intel", "amd");
        }

        [Fact]
        public void Ram_capacity_should_be_greater_than_0()
        {
            var reader = GetPlatformDataReader();
            var ram = reader.GetRamCapacity();

            ram.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Ram_usage_should_be_greater_than_0()
        {
            var reader = GetPlatformDataReader();
            var ramUsage = reader.GetRamUsage();
            ramUsage.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Disk_usage_should_be_greater_than_0()
        {
            var reader = GetPlatformDataReader();
            var disk = reader.GetDiskUsage();
            disk.Should().BeGreaterThan(0);
        }
        
        [Fact]
        public void Disk_capacity_should_be_greater_than_0()
        {
            var reader = GetPlatformDataReader();
            var disk = reader.GetDiskCapacity();
            disk.Should().BeGreaterThan(0);
        }
    }
}