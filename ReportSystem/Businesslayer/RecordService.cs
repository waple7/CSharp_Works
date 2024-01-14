using ReportSystem.DataAccesslayer;
using ReportSystem.Entities;
using ReportSystem.Exceptions;

namespace ReportSystem.Businesslayer
{
    public class RecordService : IRecordService
    {
        public void FinishJobGiveToRecord(Worker worker, int day)
        {
            var record = new Record(worker.MessageAllowed, worker, day);
            Console.WriteLine("Worker completed job");
            record.Messages.AddRange(worker.MessageAllowed);
        }
        public void CreateMasterRecord(Worker worker, Record record, int day, RepositoryWorker workerService, RepositoryRecord repositoryRecord)
        {
            if (worker.Role!= "Admin")
            {
                throw new InvalidAuthorizationFailed("InvalidAuthorizationFailed");
            }
            repositoryRecord.Add(record);

            foreach(WorkerService employee in workerService.Workers)
            {
                Console.WriteLine(employee);
            }
            Console.WriteLine(record.Messages.Count);

            foreach(Message message in worker.MessageAllowed)
            {
                Console.WriteLine(message);
            }
        }
    }
}
