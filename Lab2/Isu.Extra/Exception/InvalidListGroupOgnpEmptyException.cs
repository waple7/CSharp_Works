namespace Isu.Extra.Exceptions
{
    public class InvalidListGroupOgnpEmptyException : Exception
    {
        public InvalidListGroupOgnpEmptyException(string? message)
            : base(message)
        {
            message = "List Group Ognp Empty Exception";
        }
    }
}
