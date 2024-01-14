using Isu.Entities;
using Isu.Extra.Entities;
using Isu.Extra.Models;
using Isu.Models;

namespace Isu.Extra.Services;

public interface IIsuExtraService
{
    DisciplineOgnp AddDisciplineOgnpForGroup(string nameOgnp, string faculty, GroupName groupName, CourseNumber courseNumber, List<Student> students, string facultyGroup);
    StreamOgnp EnrollStreamOgnp(DisciplineOgnp disciplineOgnp, Lessons stream, TimetableOnWeek timetableOnWeek);
    GroupOgnp AddGroupOgnp(List<GroupOgnp> listGroupOgnp, List<Students> student, string teacher, int numberGroupOgnp, StreamOgnp streamOgnp);
    void AddStudentToGroupOgnp(Students student_, GroupOgnp group);
    IReadOnlyList<Students> DeleteStudentToGroupOgnp(List<Students> students, GroupOgnp groupOgnp);
    IReadOnlyList<GroupOgnp> GetGroups(List<GroupOgnp> listGroupOgnp);
    IReadOnlyList<Students> GetStudentsOgnpGroup(GroupOgnp groupOgnp, List<Students> students);
    IReadOnlyList<Students> NotEnrollToOgnpGroupStudentsInMainGroup(List<Students> students, GroupOgnp groupOgnp);
}