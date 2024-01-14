using System.IO.Compression;
using Backups.Exceptions;
using Backups.Services;

namespace Backups.Entities
{
    public class RestorePoint
    {
        private List<ZipArchive> _zipArchives;
        private List<FileProvider> _fileProvider;
        public RestorePoint(List<FileProvider> fileProvider, string restorePointNumber, IAlgStorage algStorage, string path)
        {
            _fileProvider = fileProvider;
            RestorePointNumber = restorePointNumber;
            CreatTime = DateTime.Now;
            _zipArchives = new List<ZipArchive>();
        }

        public IReadOnlyList<FileProvider> FileProvider => _fileProvider;
        public string RestorePointNumber { get; set; }
        public DateTime CreatTime { get; set; }

        public IReadOnlyList<ZipArchive> ZipFiles => _zipArchives;

        public void AddStorage(List<FileProvider> fileProvider, IAlgStorage algStorage, string path)
        {
            _zipArchives = (List<ZipArchive>)algStorage.AddStorage(fileProvider, RestorePointNumber, path);
        }

        public void RemoveFileProvider(FileProvider file)
        {
            _fileProvider.Remove(file);
        }

        public void AddFileProvider(FileProvider file)
        {
            _fileProvider.Add(file);
        }
    }
}
