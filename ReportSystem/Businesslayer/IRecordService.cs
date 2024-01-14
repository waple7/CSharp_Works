using ReportSystem.DataAccesslayer;
using ReportSystem.Entities;

namespace ReportSystem.Businesslayer
{
    public interface IRecordService
    {
        public void FinishJobGiveToRecord(Worker worker, int day);
        public void CreateMasterRecord(Worker worker, Record record, int day, RepositoryWorker workerService, RepositoryRecord repositoryRecord);
    }
}
