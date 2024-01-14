namespace Isu.Extra.Models
{
    public class TimetableOnWeek
    {
        public TimetableOnWeek(Lessons mainLesson1, Lessons mainLesson2, Lessons mainLesson3)
        {
            Lesson1 = mainLesson1;
            Lesson2 = mainLesson2;
            Lesson3 = mainLesson3;
        }

        public Lessons Lesson1 { get; }
        public Lessons Lesson2 { get; }
        public Lessons Lesson3 { get; }
    }
}
