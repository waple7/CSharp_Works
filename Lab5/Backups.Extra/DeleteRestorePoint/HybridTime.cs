namespace Backups.Extra.DeleteRestorePoint
{
    public class HybridTime : AbstractLimitDecorator
    {
        public HybridTime(AbstractLimitRestorePoint abstractLimitRestorePoint)
            : base(abstractLimitRestorePoint.BackupExtraService, abstractLimitRestorePoint.BackupExtraService.AlgStorage, abstractLimitRestorePoint.MaxNumber, abstractLimitRestorePoint, abstractLimitRestorePoint.LastTime)
        {
            LastTime = abstractLimitRestorePoint.LastTime;
        }

        public override int GetLimitAndDelete()
        {
            int count = 0;
            BackupExtraService.Logging.Log("Time limit" + LastTime);
            for (int i = 0; i < BackupExtraService.RestorePoints.Count; i++)
            {
                if (DateTime.Compare(BackupExtraService.RestorePoints[i].CreatTime, LastTime) <= 0)
                {
                    count += 1;
                }
            }

            for (int i = 0; i < count; i++)
            {
                BackupExtraService.RepositoryService.RemoveRestorePoint(BackupExtraService, i, BackupExtraService.AlgStorage);
            }

            BackupExtraService.Logging.Log("restore points the number limit deleted");
            return count;
        }
    }
}
