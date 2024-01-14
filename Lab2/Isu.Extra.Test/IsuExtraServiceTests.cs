using Isu.Entities;
using Isu.Extra.Entities;
using Isu.Extra.Exceptions;
using Isu.Extra.Models;
using Isu.Extra.Services;
using Isu.Models;
using Xunit;

namespace Isu.Extra.Test;

public class IsuExtraServiceTests
{
    [Fact]
    public void SameFacultyFailure()
    {
        var service = new IsuExtraService();

        var studentsMainGroup1 = new List<Student>();

        var groupName = new GroupName("M32101");
        var groupMain1 = new Groups(groupName, CourseNumber.Second, studentsMainGroup1, "FTMI");

        Assert.Throws<InvalidSameFacultyException>(() =>
        {
            service.AddDisciplineOgnpForGroup("Innovative Marketing", "FTMI", groupName, CourseNumber.Second, studentsMainGroup1, "FTMI");
        });
    }

    [Fact]
    public void IntersectionTimetableFailure()
    {
        var service = new IsuExtraService();

        var timetableOnWeekMonday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);
        var timetableOnWeekTuesday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);
        var timetableOnWeekWednesday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);
        var timetableOnWeekThursday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);
        var timetableOnWeekFriday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);
        var timetableOnWeekSunday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);

        var studentsMainGroup1 = new List<Student>();

        var groupName = new GroupName("M32101");
        var groupMain1 = new Groups(groupName, CourseNumber.Second, studentsMainGroup1, "FITIP");

        DisciplineOgnp disciplineOgnp = service.AddDisciplineOgnpForGroup("Innovative Marketing", "FTMI", groupName, CourseNumber.Second, studentsMainGroup1, "FITIP");

        Assert.Throws<InvalidIntersectionWithTheMainTimetable>(() =>
        {
            service.EnrollStreamOgnp(disciplineOgnp, Lessons.FirstPair, timetableOnWeekMonday);
        });
    }

    [Fact]
    public void StudentLimitInOgnpGroup()
    {
        var service = new IsuExtraService();

        var timetableOnWeekMonday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);
        var timetableOnWeekTuesday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);
        var timetableOnWeekWednesday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);
        var timetableOnWeekThursday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);
        var timetableOnWeekFriday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);
        var timetableOnWeekSunday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);

        var listGroupOgnp = new List<GroupOgnp>();
        var studentsMainGroup1 = new List<Student>();
        var studentOgnpGroup1 = new List<Students>();

        var groupName = new GroupName("M32101");
        var groupMain1 = new Groups(groupName, CourseNumber.Second, studentsMainGroup1, "FITIP");

        DisciplineOgnp disciplineOgnp = service.AddDisciplineOgnpForGroup("Innovative Marketing", "FTMI", groupName, CourseNumber.Second, studentsMainGroup1, "FITIP");

        StreamOgnp streamOgnp = service.EnrollStreamOgnp(disciplineOgnp, Lessons.FourthPair, timetableOnWeekMonday);

        GroupOgnp groupOgnp1 = service.AddGroupOgnp(listGroupOgnp, studentOgnpGroup1, "Ivan Ivanovich", 123, streamOgnp);
        var student1 = new Students(339576, "Radmir", "Naumenko", groupMain1, groupOgnp1);

        for (int i = 0; i < GroupOgnp.MaxStudentOgnpGroup - 1; i++)
        {
            service.AddStudentToGroupOgnp(student1, groupOgnp1);
        }

        Assert.Throws<InvalidStudentOgnpGroupLimitException>(() =>
        {
            service.AddStudentToGroupOgnp(student1, groupOgnp1);
        });
    }

    [Fact]
    public void StudentNotInGroupOgnp()
    {
        var service = new IsuExtraService();

        var timetableOnWeekMonday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);
        var timetableOnWeekTuesday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);
        var timetableOnWeekWednesday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);
        var timetableOnWeekThursday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);
        var timetableOnWeekFriday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);
        var timetableOnWeekSunday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);

        var listGroupOgnp = new List<GroupOgnp>();
        var studentsMainGroup1 = new List<Student>();
        var studentOgnpGroup1 = new List<Students>();

        var groupName = new GroupName("M32101");
        var groupMain1 = new Groups(groupName, CourseNumber.Second, studentsMainGroup1, "FITIP");

        DisciplineOgnp disciplineOgnp = service.AddDisciplineOgnpForGroup("Innovative Marketing", "FTMI", groupName, CourseNumber.Second, studentsMainGroup1, "FITIP");

        StreamOgnp streamOgnp = service.EnrollStreamOgnp(disciplineOgnp, Lessons.FourthPair, timetableOnWeekMonday);

        GroupOgnp groupOgnp1 = service.AddGroupOgnp(listGroupOgnp, studentOgnpGroup1, "Ivan Ivanovich", 123, streamOgnp);
        var student1 = new Students(339576, "Radmir", "Naumenko", groupMain1, groupOgnp1);

        service.AddStudentToGroupOgnp(student1, groupOgnp1);
        service.DeleteStudentToGroupOgnp(studentOgnpGroup1, groupOgnp1);

        Assert.Throws<InvalidStudentNotGroupOgnpException>(() =>
        {
            service.DeleteStudentToGroupOgnp(studentOgnpGroup1, groupOgnp1);
        });
    }

    [Fact]
    public void NotGetGroupOgnp()
    {
        var service = new IsuExtraService();

        var timetableOnWeekMonday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);
        var timetableOnWeekTuesday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);
        var timetableOnWeekWednesday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);
        var timetableOnWeekThursday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);
        var timetableOnWeekFriday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);
        var timetableOnWeekSunday = new TimetableOnWeek(Lessons.FirstPair, Lessons.SecondPair, Lessons.ThirdPair);

        var listGroupOgnp = new List<GroupOgnp>();
        var studentsMainGroup1 = new List<Student>();
        var studentOgnpGroup1 = new List<Students>();

        var groupName = new GroupName("M32101");
        var groupMain1 = new Groups(groupName, CourseNumber.Second, studentsMainGroup1, "FITIP");

        DisciplineOgnp disciplineOgnp = service.AddDisciplineOgnpForGroup("Innovative Marketing", "FTMI", groupName, CourseNumber.Second, studentsMainGroup1, "FITIP");

        StreamOgnp streamOgnp = service.EnrollStreamOgnp(disciplineOgnp, Lessons.FourthPair, timetableOnWeekMonday);

        Assert.Throws<InvalidListGroupOgnpEmptyException>(() =>
        {
            service.GetGroups(listGroupOgnp);
        });
    }
}