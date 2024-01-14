namespace Isu.Extra.Entities
{
    public class DisciplineOgnp
    {
        public DisciplineOgnp(string nameOgnp, string faculty)
        {
            NameOgnp = nameOgnp;
            Faculty = faculty;
        }

        public string NameOgnp { get; }
        public string Faculty { get; }
    }
}
