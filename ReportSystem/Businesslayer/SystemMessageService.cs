using ReportSystem.Businesslayer;
using ReportSystem.DataAccesslayer;
using ReportSystem.Exceptions;

namespace ReportSystem.Entities
{
    public class SystemMessageService : RepositoryMessages, ISystemMessageService
    {
        public SystemMessageService(TypeMessage typeMessage, int stageMessageNew, string message, List<TypeMessage> typeMessages, List<Message> messages) : base(typeMessage, stageMessageNew, message, typeMessages, messages)
        {
        }

        public void AddNewType(TypeMessage typeMessage)
        {
            TypeMessage.Add(typeMessage);
        }

        public void AddMessage(Message message)
        {
            Add(message);
        }

        public void MessageChecked(Worker worker, Message message)
        {
            if (worker.Role != "Admin" || worker.Role != "Operator")
            {
                throw new InvalidAuthorizationFailed("AuthorizationFailed");
            }

            StageMessageNew += 1;
            Console.WriteLine("message stage 2 - viewed succesfully");
            MessageAllowed(worker, message);
        }

        public void MessageAllowed(Worker worker, Message message)
        {
            if (StageMessageNew != 2)
            {
                throw new InvalidMessageNotCheck("message was not viewed");
            }

            if (worker.Role != "Admin" || worker.Role != "Operator")
            {
                throw new InvalidAuthorizationFailed("AuthorizationFailed");
            }

            StageMessageNew += 1;
            Console.WriteLine("message stage 3 - accepted");
            worker.MessageAllowed.Add(message);
        }
    }
}
