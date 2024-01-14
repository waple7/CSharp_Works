namespace ReportSystem.Entities
{
    public class Record
    {
        public Record(List<Message> messages, Worker worker, int day)
        {
            Messages = messages;
            Worker = worker;
            Day = day;
        }

        public List<Message> Messages { get; set; }
        public Worker Worker { get; set; }
        public int Day { get; set; }
        }
    }
