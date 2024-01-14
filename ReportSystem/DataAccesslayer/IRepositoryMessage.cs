using ReportSystem.Entities;

namespace ReportSystem.DataAccesslayer
{
    public interface IRepositoryMessage
    {
        public void Add(Message message);
        public void MessageWasChecked(Message message);
        public IEnumerable<Message> GetAll();
        public void Update(Message entity);
    }
}
