using Isu.Models;

namespace Isu.Exceptions
{
    public class InvalidGroupNotListedException : Exception
    {
        public InvalidGroupNotListedException(GroupName groupName)
        {
            GroupName = groupName;
        }

        public GroupName GroupName { get; }
    }
}