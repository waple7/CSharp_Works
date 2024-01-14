namespace Backups.Exceptions
{
    public class InvalidFileNullException : Exception
    {
        public InvalidFileNullException(string? message)
            : base(message)
        {
            message = "File Null";
        }
    }
}
