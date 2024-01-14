using Isu.Entities;
using Isu.Models;

namespace Isu.Extra.Entities;

public class Groups : Group
{
    public Groups(GroupName groupName, CourseNumber courseNumber, List<Student> students, string faculty)
        : base(groupName, courseNumber, students)
    {
        Faculty = faculty;
    }

    public string Faculty { get; }
}