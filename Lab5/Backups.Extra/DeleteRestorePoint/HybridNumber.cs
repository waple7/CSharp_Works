namespace Backups.Extra.DeleteRestorePoint
{
    public class HybridNumber : AbstractLimitDecorator
    {
        public HybridNumber(AbstractLimitRestorePoint abstractLimitRestorePoint)
            : base(abstractLimitRestorePoint.BackupExtraService, abstractLimitRestorePoint.BackupExtraService.AlgStorage, abstractLimitRestorePoint.MaxNumber, abstractLimitRestorePoint, abstractLimitRestorePoint.LastTime)
        {
            MaxCount = abstractLimitRestorePoint.MaxNumber;
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
