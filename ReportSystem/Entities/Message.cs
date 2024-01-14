namespace ReportSystem.Entities
{
    public class Message
    {
        public Message(TypeMessage typeMessage, int stageMessageNew, string report)
        {
            Messages = typeMessage;
            StageMessageNew = stageMessageNew;
            Report = report;
        }
        public TypeMessage Messages { get; set; }
        public int StageMessageNew { get; set; } = 1;
        public string Report { get; set; }
    }
}
