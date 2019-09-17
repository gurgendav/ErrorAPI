namespace ErrorAPI.DTO
{
    public class ErrorDetails
    {
        public EnvironmentDetails EnvironmentDetails { get; }
        public ExceptionHandlingDetails ExceptionHandlingDetails { get; }
        public ExceptionDetails ExceptionDetails { get; }

        public string FaultingContextDetails { get; }
        public string ProgramName { get; }

        public ErrorDetails(EnvironmentDetails environmentDetails, ExceptionHandlingDetails exceptionHandlingDetails, ExceptionDetails exceptionDetails, string faultingContextDetails, string programName)
        {
            EnvironmentDetails = environmentDetails;
            ExceptionHandlingDetails = exceptionHandlingDetails;
            ExceptionDetails = exceptionDetails;
            FaultingContextDetails = faultingContextDetails;
            ProgramName = programName;
        }
    }
}