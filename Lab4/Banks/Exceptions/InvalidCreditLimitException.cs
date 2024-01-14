namespace Banks.Exceptions
{
    public class InvalidCreditLimitException : Exception
    {
        public InvalidCreditLimitException(string? message)
            : base(message)
        {
            message = "Credit limit error";
        }
    }
}
