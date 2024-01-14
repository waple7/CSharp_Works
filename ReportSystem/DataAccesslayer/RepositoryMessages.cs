using ReportSystem.Entities;

namespace ReportSystem.DataAccesslayer
{
    public class RepositoryMessages : Message, IRepositoryMessage
    {
        public RepositoryMessages(TypeMessage typeMessage, int stageMessageNew, string message, List<TypeMessage> typeMessages, List<Message> messages) : base(typeMessage, stageMessageNew, message)
        {
            TypeMessage = typeMessages;
            Message = messages;
        }

        public List<Message> Message { get; set; }
        public List<TypeMessage> TypeMessage { get; set; }
        public void Add(Message message)
        {
            Message.Add(message);
        }

        public void MessageWasChecked(Message message)
        {
            StageMessageNew += 1;
        }

        public IEnumerable<Message> GetAll()
        {
            return Message;
        }

        public void Update(Message entity)
        {
            Message.Remove(entity);
            Message.Add(entity);
        }
    }
}
