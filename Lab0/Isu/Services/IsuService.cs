using Isu.Entities;
using Isu.Exceptions;
using Isu.Models;

namespace Isu.Services
{
    public class IsuService : IIsuService
    {
        private readonly List<Group> groupList = new ();
        private readonly List<Student> studentList = new ();
        private int studentIdCounter;

        public Group AddGroup(string name, CourseNumber courseNumber, List<Student> students)
        {
            if (!GroupName.TryParse(name, out GroupName? group))
            {
                throw new InvalidGroupNameException(name);
            }

            if (group == null)
            {
                throw new ArgumentNullException();
            }

            var group_ = new Group(group, courseNumber, students);

            studentList.AddRange(students);
            groupList.Add(group_);
            return group_;
        }

        public Student AddStudent(Group group, string firstName, string lastName)
        {
            if (group.Students.Count >= Group.MaxStudent)
            {
                throw new InvalidStudentLimitException(group.Students.Count);
            }

            var newStudent = new Student(studentIdCounter++, firstName, lastName, group);

            if (newStudent == null)
            {
                throw new NullReferenceException();
            }

            studentList.Add(newStudent);
            group.AddStudent(newStudent);
            return newStudent;
        }

        public Student GetStudent(int id)
        {
            var studentToFind = studentList.Where(student => student.Id == id).ToList();
            studentToFind.SingleOrDefault();
            if (studentToFind == null)
            {
                throw new InvalidStudentNotListedException(id);
            }

            return studentToFind[0];
        }

        public Student FindStudent(int id)
        {
            var studentToFind = studentList.Where(student => student.Id == id).ToList();
            studentToFind.SingleOrDefault();

            return studentToFind[0];
        }

        public List<Student> FindStudents(GroupName groupName)
        {
            var studentsToFind = studentList.Where(student => student.Group.GroupName == groupName).ToList();
            return studentsToFind;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            var studentsToFind = studentList.Where(student => student.Group.CourseNumber == courseNumber).ToList();
            return studentsToFind;
        }

        public Group FindGroup(GroupName groupName)
        {
            var groupsToFind = groupList.Where(group => group.GroupName == groupName).ToList();

            if (groupsToFind.Any())
            {
                return groupsToFind[0];
            }
            else
            {
                throw new InvalidGroupNotListedException(groupName);
            }
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            var groupsToFind = groupList.Where(group => group.CourseNumber == courseNumber).ToList();

            return groupsToFind;
        }

        public void ChangeStudentGroup(Student student, Group groupNew, Group groupDefault)
        {
            groupDefault.DeleteStudent(student);

            groupNew.AddStudent(student);
        }
    }
}