using Isu.Extra.Models;

namespace Isu.Extra.Entities
{
    public class StreamOgnp
    {
        public StreamOgnp(DisciplineOgnp disciplineOgnp, Lessons stream)
        {
            DisciplineOgnp = disciplineOgnp;
            Lessons = stream;
        }

        public DisciplineOgnp DisciplineOgnp { get; }
        public Lessons Lessons { get; }
    }
}
