using System;

namespace ErrorAPI.DB.Entities
{
    public class ErrorDetails
    {
        public int Id { get; set; }

        public Error Error { get; set; }

        public DateTime DateUtc { get; set; }

        public string FaultingContextDetails { get; set; }

        public string Version { get; set; }
        public string MachineName { get; set; }
        public string MachineOsVersion { get; set; }
        public double UsedMemoryMb { get; set; }
        public string UserName { get; set; }

        public bool CanUserContinue { get; set; }
        public bool DidUserContinue { get; set; }
    }
}