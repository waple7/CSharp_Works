namespace Isu.Entities;
public class Student
{
    public Student(int id, string firstName, string lastName, Group group)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Group = group;
    }

    public int Id { get; }
    public Group Group { get; }

    public string FirstName { get; }

    public string LastName { get; }
}