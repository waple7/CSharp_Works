namespace Isu.Extra.Exceptions
{
    public class InvalidIntersectionWithTheMainTimetable : Exception
    {
        public InvalidIntersectionWithTheMainTimetable(string? message)
            : base(message)
        {
            message = "Intersection With Main Timetable";
        }
    }
}
