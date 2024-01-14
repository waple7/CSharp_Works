using Backups.Services;

namespace Backups.Extra.DeleteRestorePoint
{
    public abstract class AbstractLimitDecorator : AbstractLimitRestorePoint
    {
        public AbstractLimitDecorator(BackupExtraService backup, IAlgStorage algStorage, int maxCount, AbstractLimitRestorePoint abstractLimitRestorePoint, DateTime lastTime)
            : base(backup, algStorage, maxCount, lastTime)
        {
            AbstractLimitRestorePoint = abstractLimitRestorePoint;
        }

        public AbstractLimitRestorePoint AbstractLimitRestorePoint { get; set; }
    }
}
