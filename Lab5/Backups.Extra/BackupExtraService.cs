using Backups.Entities;
using Backups.Extra.Logging;
using Backups.Services;

namespace Backups.Extra
{
    public class BackupExtraService : BackupTask
    {
        public BackupExtraService(string path, IAlgStorage algStorage, ILogger logging)
            : base(path, algStorage)
        {
            Path = path;
            Logging = logging;
            RepositoryService = new MyRepositoryExtra(path);
        }

        public ILogger Logging { get; set; }
        public MyRepositoryExtra RepositoryService { get; set; }
        public void AddFile(string filePath, string fileName)
        {
            Add(filePath, fileName);
            Logging.Log("file added");
        }

        public void RemoveFile(string filePath, string fileName)
        {
            Remove(filePath, fileName);
            Logging.Log("file removed");
        }

        public void MakeRestorePointExtra()
        {
            RestorePoint();
            Logging.Log("Restore point created");
        }

        public bool CheckFile(int restorePointNumber, string filePath)
        {
            return RestorePoints[restorePointNumber - 1].FileProvider.Any(file => file.FileName == filePath);
        }
    }
}
