using System.IO.Compression;

namespace Backups.Services
{
    public interface IAlgStorage
    {
        IReadOnlyList<ZipArchive> AddStorage(List<FileProvider> fileProvider, string restorePointNumber, string path);
    }
}
