namespace Isu.Exceptions
{
    public class InvalidStudentLimitException : Exception
    {
        public InvalidStudentLimitException(int countStudents)
        {
            CountStudents = countStudents;
        }

        public int CountStudents { get; }
    }
}