namespace Isu.Extra.Exceptions
{
    public class InvalidSameFacultyException : Exception
    {
        public InvalidSameFacultyException(string? message)
            : base(message)
        {
            message = "Same Faculty Exception";
        }
    }
}
