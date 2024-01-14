using Backups.Services;

namespace Backups.Extra.DeleteRestorePoint
{
    public class LimitNumberRestorePoint : AbstractLimitRestorePoint
    {
        public LimitNumberRestorePoint(BackupExtraService backup, int maxCount, IAlgStorage algStorage, DateTime lastTime)
            : base(backup, algStorage, maxCount, lastTime)
        {
            MaxCount = maxCount;
        }

        public int MaxCount { get; set; }
        public override int GetLimitAndDelete()
        {
            int limit = BackupExtraService.RestorePoints.Count - MaxCount;
            BackupExtraService.Logging.Log("Number limit " + MaxCount);

            for (int i = 0; i < limit; i++)
            {
                BackupExtraService.RepositoryService.RemoveRestorePoint(BackupExtraService, i, BackupExtraService.AlgStorage);
            }

            BackupExtraService.Logging.Log("restore points the number limit deleted");
            return limit;
        }
    }
}
