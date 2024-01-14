namespace Isu.Extra.Exceptions
{
    public class InvalidNumberGroupOgnpException : Exception
    {
        public InvalidNumberGroupOgnpException(string? message)
            : base(message)
        {
            message = "Wrong number group";
        }
    }
}
