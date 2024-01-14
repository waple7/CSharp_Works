using Isu.Models;

namespace Isu.Entities;

public class Group
{
    public const int MaxStudent = 30;
    public Group(GroupName groupName, CourseNumber courseNumber, List<Student> students)
    {
        CourseNumber = courseNumber;
        GroupName = groupName;
        Students = students;
    }

    public CourseNumber CourseNumber { get; }
    public List<Student> Students { get; }
    public GroupName GroupName { get; }
    public void AddStudent(Student student)
    {
        Students.Add(student);
    }

    public void DeleteStudent(Student student)
    {
        Students.Remove(student);
    }
}