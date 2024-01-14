using ReportSystem.DataAccesslayer;
using ReportSystem.Entities;
using ReportSystem.Exceptions;

namespace ReportSystem.Businesslayer
{
    public class WorkerService : RepositoryWorker, IWorkerService
    {
        public WorkerService(string name, string role, List<Message> allowedMessages, int password, List<Worker> workers) : base(name, role, allowedMessages, password, workers)
        {
        }

        public void LogIn(Worker worker, string role, int password)
        {
            var logIn = Workers.Where(employee => employee.Role == role && worker == employee && employee.Password == password).ToList();
            logIn.SingleOrDefault();
            if (logIn == null || Workers.Count==0)
            {
                throw new InvalidAuthenticationfailedException("authentication failed");
            }
            else
            {
                Console.WriteLine("authentication successfully");
            }
        }
        public void AddWorker(Worker worker, List<Message> messages)
        {
            Add(worker);
            Console.WriteLine("create worker succesfully");
        }

        public void DeleteWorker(Worker worker)
        {
            Delete(worker);
            Console.WriteLine("delete worker succesfully");
        }

        public void GetAllWorker()
        {
            GetAll();
            Console.WriteLine("delete worker succesfully");
        }

        public void GetByNameEmployee(string name)
        {
            GetByName(name);
        }

        public void ChangeRole(Worker worker, string newRole)
        {
            worker.Role = newRole;
        }
    }
}
