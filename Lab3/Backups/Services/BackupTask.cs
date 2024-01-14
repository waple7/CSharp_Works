using Backups.Exceptions;
using Backups.Services;

namespace Backups.Entities
{
    public class BackupTask : IBackupTask
    {
        private List<FileProvider> _fileProvider;
        private List<RestorePoint> _restorePoint;
        public BackupTask(string path, IAlgStorage algStorage)
        {
            _fileProvider = new List<FileProvider>();
            AlgStorage = algStorage;
            MyRepository = new Repository(path);
            Path = path;
            _restorePoint = new List<RestorePoint>();
        }

        public string Path { get; set; }
        public IReadOnlyList<FileProvider> FileProvider => _fileProvider;
        public IAlgStorage AlgStorage { get; set; }
        public IReadOnlyList<RestorePoint> RestorePoints => _restorePoint;
        public Repository MyRepository { get; set; }
        public void Add(string filePath, string fileName)
        {
            _fileProvider.Add(new FileProvider(filePath, fileName));
        }

        public void Remove(string filePath, string fileName)
        {
            var fileProvider = FileProvider.Where(removeFileProvider => removeFileProvider.FilePath == filePath &&
            removeFileProvider.FileName == fileName).ToList();
            fileProvider.FirstOrDefault();
            if (fileProvider != null)
            {
                _fileProvider.Remove(fileProvider[0]);
            }
            else
            {
                throw new InvalidFileNullException("File Null");
            }
        }

        public void DeleteRestorePoint(int restorePointNumber)
        {
            _restorePoint.Remove(RestorePoints[restorePointNumber]);
        }

        public void RestorePoint()
        {
            var restorePoint = new RestorePoint(_fileProvider, (RestorePoints.Count + 1).ToString(), AlgStorage, Path);
            restorePoint.AddStorage(_fileProvider, AlgStorage, Path);
            _restorePoint.Add(restorePoint);
        }

        public int CheckStorage(int restorePoint)
        {
            return RestorePoints[restorePoint - 1].ZipFiles.Count;
        }
    }
}