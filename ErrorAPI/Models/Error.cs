using System.Collections.Generic;

namespace ErrorAPI.Models
{
    public class Error
    {
        public int Id { get; set; }

        public string ExceptionName { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionMessage { get; set; }
        public string StackTrace { get; set; }

        public string ProgramName { get; set; }

        public int OccurenceCount { get; set; }

        public List<ErrorDetails> ErrorDetails {get; set; }
    }
}