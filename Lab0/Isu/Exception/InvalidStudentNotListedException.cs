namespace Isu.Exceptions
{
    public class InvalidStudentNotListedException : Exception
    {
        public InvalidStudentNotListedException(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}