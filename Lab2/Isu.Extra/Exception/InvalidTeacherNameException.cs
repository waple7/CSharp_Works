namespace Isu.Extra.Exceptions
{
    public class InvalidTeacherNameException : Exception
    {
        public InvalidTeacherNameException(string? message)
            : base(message)
        {
            message = "Wrong teacher name";
        }
    }
}
