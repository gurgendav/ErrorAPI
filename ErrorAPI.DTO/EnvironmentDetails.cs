using System;

namespace ErrorAPI.DTO
{
    public class EnvironmentDetails
    {
        public string Version { get; }
        public string MachineName { get; }
        public string MachineOsVersion { get; }
        public double UsedMemoryMb { get; }
        public string UserName { get; }
        public DateTime DateUtc { get; }

        public EnvironmentDetails(string version, string machineName, string machineOsVersion, double usedMemoryMb, string userName, DateTime dateUtc)
        {
            Version = version;
            MachineName = machineName;
            MachineOsVersion = machineOsVersion;
            UsedMemoryMb = usedMemoryMb;
            UserName = userName;
            DateUtc = dateUtc;
        }
    }
}