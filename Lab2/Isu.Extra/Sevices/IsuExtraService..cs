using Isu.Entities;
using Isu.Extra.Entities;
using Isu.Extra.Exceptions;
using Isu.Extra.Models;
using Isu.Models;

namespace Isu.Extra.Services
{
    public class IsuExtraService : IIsuExtraService
    {
        public DisciplineOgnp AddDisciplineOgnpForGroup(string nameOgnp, string faculty, GroupName groupName, CourseNumber courseNumber, List<Student> students, string facultyGroup)
        {
            if (string.IsNullOrWhiteSpace(nameOgnp))
            {
                throw new InvalidNullNameOgnpException("Null or white space nameOgnp");
            }

            if (string.IsNullOrWhiteSpace(faculty))
            {
                throw new InvalidNullFacultyException("Null or white space faculty");
            }

            if (string.IsNullOrWhiteSpace(facultyGroup))
            {
                throw new InvalidNullFacultyException("Null or white space faculty");
            }

            var disciplineOgnp = new DisciplineOgnp(nameOgnp, faculty);
            if (disciplineOgnp.Faculty == facultyGroup)
            {
                throw new InvalidSameFacultyException("Same Faculty Exception");
            }

            return disciplineOgnp;
        }

        public StreamOgnp EnrollStreamOgnp(DisciplineOgnp disciplineOgnp, Lessons stream, TimetableOnWeek timetableOnWeek)
        {
            var enrollStreamOgnp = new StreamOgnp(disciplineOgnp,  stream);

            if ((enrollStreamOgnp.Lessons == timetableOnWeek.Lesson1) || (enrollStreamOgnp.Lessons == timetableOnWeek.Lesson2)
                || (enrollStreamOgnp.Lessons == timetableOnWeek.Lesson3))
            {
                throw new InvalidIntersectionWithTheMainTimetable("Intersection With Main Timetable");
            }

            return enrollStreamOgnp;
        }

        public GroupOgnp AddGroupOgnp(List<GroupOgnp> listGroupOgnp, List<Students> student, string teacher, int numberGroupOgnp, StreamOgnp streamOgnp)
        {
            if (string.IsNullOrWhiteSpace(teacher))
            {
                throw new InvalidTeacherNameException("Wrong teacher name");
            }

            if (numberGroupOgnp == 0 || numberGroupOgnp < 0)
            {
                throw new InvalidNumberGroupOgnpException("Wrong number group");
            }

            var groupOgnp = new GroupOgnp(streamOgnp, teacher, numberGroupOgnp, student);
            listGroupOgnp.Add(groupOgnp);
            return groupOgnp;
        }

        public void AddStudentToGroupOgnp(Students student_, GroupOgnp group)
        {
            group.AddToList(student_);
            group.CountStudents();
        }

        public IReadOnlyList<Students> DeleteStudentToGroupOgnp(List<Students> students, GroupOgnp groupOgnp)
        {
            var studentToFind = students.Where(student => groupOgnp == student.GroupOgnp).ToList();
            studentToFind.FirstOrDefault();

            if (studentToFind.Count != 0)
            {
                students.Remove(students[0]);
                return students;
            }
            else
            {
                throw new InvalidStudentNotGroupOgnpException("Student Not in GroupOgnp");
            }
        }

        public IReadOnlyList<GroupOgnp> GetGroups(List<GroupOgnp> listGroupOgnp)
        {
            if (listGroupOgnp.Count == 0)
            {
                throw new InvalidListGroupOgnpEmptyException("List Group Ognp Empty Exception");
            }

            return listGroupOgnp;
        }

        public IReadOnlyList<Students> GetStudentsOgnpGroup(GroupOgnp groupOgnp, List<Students> students)
        {
            var studentsToFind = students.Where((student) => groupOgnp == student.GroupOgnp).ToList();
            if (studentsToFind is not null)
            {
                return students;
            }
            else
            {
                throw new InvalidtGroupOgnpNullException("Group Ognp has not student");
            }
        }

        public IReadOnlyList<Students> NotEnrollToOgnpGroupStudentsInMainGroup(List<Students> students, GroupOgnp groupOgnp)
        {
            groupOgnp.CheckStudents(students);

            return students;
        }
    }
}