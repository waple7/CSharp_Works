namespace Isu.Extra.Exceptions
{
    public class InvalidtGroupOgnpNullException : Exception
    {
        public InvalidtGroupOgnpNullException(string? message)
            : base(message)
        {
            message = "Group Ognp has not student";
        }
    }
}
