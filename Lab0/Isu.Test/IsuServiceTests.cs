using Isu.Entities;
using Isu.Exceptions;
using Isu.Models;
using Isu.Services;
using Xunit;
using Group = Isu.Entities.Group;

namespace Isu.Test;

public class IsuServiceTests
{
    [Fact]
    public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
    {
        var students = new List<Student>();
        var service = new IsuService();
        Group newGroup = service.AddGroup("M32101", CourseNumber.Second, students);
        Student student = service.AddStudent(newGroup, "Radmir", "Naumenko");

        Assert.Equal(student.Group, newGroup);
        Assert.Equal(newGroup.Students, students);
    }

    [Fact]
    public void ReachMaxStudentPerGroup_ThrowException()
    {
        var students = new List<Student>();
        var service = new IsuService();
        Group group = service.AddGroup("M32101", CourseNumber.Second, students);

        for (int i = 0; i < Group.MaxStudent; i++)
        {
            service.AddStudent(group, "Radmir", "Naumenko");
        }

        Assert.Throws<InvalidStudentLimitException>(() =>
        {
            service.AddStudent(group, "Radmir", "Naumenko");
        });
    }

    [Fact]
    public void CreateGroupWithInvalidName_ThrowException()
    {
        var service = new IsuService();
        var students = new List<Student>();

        Assert.Throws<InvalidGroupNameException>(() => service.AddGroup("132101", CourseNumber.First, students));
    }

    [Fact]
    public void TransferStudentToAnotherGroup_GroupChanged()
    {
        var service = new IsuService();
        var students1 = new List<Student>();
        var students2 = new List<Student>();
        Group groupDefault = service.AddGroup("M32101", CourseNumber.Second, students1);
        Group groupNew = service.AddGroup("M32111", CourseNumber.Second, students2);
        Student student = service.AddStudent(groupDefault, "Radmir", "Naumenko");
        service.ChangeStudentGroup(student, groupNew, groupDefault);

        Assert.DoesNotContain(student, groupDefault.Students);
        Assert.Contains(student, groupNew.Students);
    }
}