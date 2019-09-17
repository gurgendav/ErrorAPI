using System;

namespace ErrorAPI.DTO
{
    public class ExceptionDetails
    {
        public string ExceptionName { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionMessage { get; set; }
        public string StackTrace { get; set; }

        public ExceptionDetails()
        {
        }

        public ExceptionDetails(Exception exception)
        {
            var type = exception.GetType();

            ExceptionName = type.Name;
            ExceptionType = type.FullName;
            ExceptionMessage = exception.Message;
            StackTrace = exception.StackTrace;
        }
    }
}