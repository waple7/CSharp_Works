namespace Banks.Exceptions
{
    public class InvalidVerificationAccountException : Exception
    {
        public InvalidVerificationAccountException(string? message)
            : base(message)
        {
            message = "Account not verificate and error limit transfer ";
        }
    }
}
