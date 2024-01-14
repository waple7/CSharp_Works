namespace Isu.Extra.Exceptions
{
    public class InvalidStudentNotGroupOgnpException : Exception
    {
        public InvalidStudentNotGroupOgnpException(string? message)
            : base(message)
        {
            message = "Student Not in GroupOgnp";
        }
    }
}
