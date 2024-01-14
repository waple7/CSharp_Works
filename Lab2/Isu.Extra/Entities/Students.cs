using Isu.Entities;

namespace Isu.Extra.Entities;

public class Students : Student
{
    public Students(int id, string firstName, string lastName, Group group, GroupOgnp groupoGNP)
        : base(id, firstName, lastName, group)
    {
        GroupOgnp = groupoGNP;
    }

    public GroupOgnp GroupOgnp { get; }
}