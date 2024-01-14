namespace ReportSystem.Entities
{
    public class Worker
    {
        public Worker(string name, string role, List<Message> messageAllowed, int password)
        {
            Name = name;
            Role = role;
            MessageAllowed = messageAllowed;
            Password = password;
        }

        public string Name { get; set; }
        public string Role { get; set; }
        public List<Message> MessageAllowed { get; set; }
        public int Password { get; set; }
    }
}
