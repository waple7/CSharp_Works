namespace Isu.Extra.Exceptions
{
    public class InvalidNullFacultyException : Exception
    {
        public InvalidNullFacultyException(string? message)
            : base(message)
        {
            message = "Null or white space faculty";
        }
    }
}
