using Isu.Extra.Exceptions;

namespace Isu.Extra.Entities
{
    public class GroupOgnp
    {
        public const int MaxStudentOgnpGroup = 30;
        private List<Students> _students;
        public GroupOgnp(StreamOgnp streamOgnp, string teacher, int numberGroupOgnp, List<Students> students)
        {
            StreamOgnp = streamOgnp;
            Teacher = teacher;
            NumberGroupOgnp = numberGroupOgnp;
            _students = students;
        }

        public StreamOgnp StreamOgnp { get; }
        public string Teacher { get; }
        public int NumberGroupOgnp { get; }
        public IReadOnlyList<Students> Students => _students;
        public void AddToList(Students students)
        {
            _students.Add(students);
        }

        public void CountStudents()
        {
            if (_students.Count >= MaxStudentOgnpGroup)
            {
                throw new InvalidStudentOgnpGroupLimitException("Student Ognp Group Limit");
            }
        }

        public void CheckStudents(List<Students> students)
        {
            foreach (Students student in Students)
            {
                if (Students.Contains(student))
                {
                    continue;
                }
                else
                {
                    students.Add(student);
                }
            }
        }
    }
}
