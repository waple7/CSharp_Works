namespace Isu.Extra.Exceptions
{
    public class InvalidNullNameOgnpException : Exception
    {
        public InvalidNullNameOgnpException(string? message)
            : base(message)
        {
            message = "Null or white space nameOgnp";
        }
    }
}
