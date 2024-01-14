using ReportSystem.Entities;

namespace ReportSystem.DataAccesslayer
{
    public class RepositoryWorker : Worker, IRepositoryWorker<Worker>
    {
        public RepositoryWorker(string name, string role, List<Message> allowedMessages, int password, List<Worker> workers)
            : base(name, role, allowedMessages, password)
        {
            Workers = workers;
        }
        public List<Worker> Workers { get; set; }
        public void Add(Worker entity)
        {
            Workers.Add(entity);
        }

        public void Delete(Worker entity)
        {
            Workers.Remove(entity);
        }

        public IEnumerable<Worker> GetAll()
        {
            return Workers;
        }

        public Worker GetByName(string name)
        {
            IEnumerable<Worker> searchWorker = Workers.Where(employee => employee.Name == name);
            searchWorker.SingleOrDefault();
            if (searchWorker == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                return (Worker)searchWorker;
            }
        }

        public void Update(Worker entity)
        {
            Workers.Remove(entity);
            Workers.Add(entity);
        }
    }
}
