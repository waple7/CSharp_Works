namespace Isu.Extra.Exceptions
{
    public class InvalidStudentOgnpGroupLimitException : Exception
    {
        public InvalidStudentOgnpGroupLimitException(string? message)
            : base(message)
        {
            message = "Student Ognp Group Limit";
        }
    }
}
