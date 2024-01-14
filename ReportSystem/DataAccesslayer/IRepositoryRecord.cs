using ReportSystem.Entities;

namespace ReportSystem.DataAccesslayer
{
    public interface IRepositoryRecord
    {
        public void Add(Record record);
        public void Delete(Record record);
        public IEnumerable<Record> GetAll();
        public Worker GetByName(int day);
        public void Update(Record record);
    }
}
