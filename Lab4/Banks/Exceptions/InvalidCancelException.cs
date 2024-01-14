namespace Banks.Exceptions
{
    public class InvalidCancelException : Exception
    {
        public InvalidCancelException(string? message)
            : base(message)
        {
            message = "Was cancel";
        }
    }
}
