using Backups.Services;

namespace Backups.Extra.DeleteRestorePoint
{
    public abstract class AbstractLimitRestorePoint
    {
        public AbstractLimitRestorePoint(BackupExtraService backup, IAlgStorage algStorage, int maxNumber, DateTime lastTime)
        {
            BackupExtraService = backup;
            MaxNumber = maxNumber;
            LastTime = lastTime;
        }

        public DateTime LastTime { get; set; }
        public BackupExtraService BackupExtraService { get; set; }
        public int MaxNumber { get; set; }
        public abstract int GetLimitAndDelete();
    }
}
