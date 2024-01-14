using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSystem.Exceptions
{
    public class InvalidAuthenticationfailedException : Exception
    {
        public InvalidAuthenticationfailedException(string? message)
            : base(message)
        {
            message = "authentication failed";
        }
    }
}
