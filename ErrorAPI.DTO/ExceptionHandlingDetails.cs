namespace ErrorAPI.DTO
{
    public class ExceptionHandlingDetails
    {
        public bool CanContinue { get; }
        public bool UserContinues { get; }

        public ExceptionHandlingDetails(bool canContinue, bool userContinues)
        {
            CanContinue = canContinue;
            UserContinues = userContinues;
        }
    }
}