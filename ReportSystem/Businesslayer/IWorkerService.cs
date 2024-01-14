using ReportSystem.Entities;

namespace ReportSystem.Businesslayer
{
    public interface IWorkerService
    {
        public void LogIn(Worker worker, string role, int password);
        public void AddWorker(Worker worker, List<Message> messages);
        public void ChangeRole(Worker worker, string newRole);
    }
}
