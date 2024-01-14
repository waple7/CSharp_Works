namespace Backups
{
    public interface IBackupTask
    {
        void Add(string filePath, string fileName);
        void Remove(string filePath, string fileName);
        void RestorePoint();
        public int CheckStorage(int restorePoint);
    }
}
