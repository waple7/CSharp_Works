namespace ReportSystem.Exceptions
{
    public class InvalidMessageNotCheck : Exception
    {
        public InvalidMessageNotCheck(string? message)
            : base(message)
        {
            message = "authorizationFailed";
        }
    }
}
