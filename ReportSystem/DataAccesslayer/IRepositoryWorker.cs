namespace ReportSystem.DataAccesslayer
{
    public interface IRepositoryWorker<Worker>
    {
        public void Add(Worker entity);
        public void Delete(Worker entity);
        public void Update(Worker entity);
        public Worker GetByName(string name);
        public IEnumerable<Worker> GetAll();
    }
}
