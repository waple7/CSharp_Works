namespace ReportSystem.Exceptions
{
        public class InvalidAuthorizationFailed : Exception
        {
            public InvalidAuthorizationFailed(string? message)
                : base(message)
            {
                message = "authorizationFailed";
            }
        }
}
