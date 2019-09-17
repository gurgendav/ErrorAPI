using System;
using System.Collections.Generic;

namespace ErrorAPI.DB.Entities
{
    public class Error
    {
        public int Id { get; set; }

        public string ExceptionName { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionMessage { get; set; }
        public string StackTrace { get; set; }

        public Program Program { get; set; }

        public List<ErrorDetails> ErrorDetails { get; set; } = new List<ErrorDetails>();
    }
}