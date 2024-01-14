using ReportSystem.Entities;

namespace ReportSystem.DataAccesslayer
{
    public class RepositoryRecord : Record, IRepositoryRecord
    {
        public RepositoryRecord(List<Message> messages, Worker worker, int day, List<Record> records) : base(messages, worker, day)
        {
            Record = records;
        }
        public List<Record> Record { get; set; }
        public void Add(Record record)
        {
            Record.Add(record);
        }

        public void Delete(Record record)
        {
            Record.Remove(record);
        }

        public IEnumerable<Record> GetAll()
        {
            return Record;
        }

        public Worker GetByName(int day)
        {
            IEnumerable<Record> searchRecord = Record.Where(record => record.Day == day);
            searchRecord.SingleOrDefault();
            if (searchRecord == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                return (Worker)searchRecord;
            }
        }

        public void Update(Record record)
        {
            Record.Remove(record);
            Record.Add(record);
        }
    }
}
