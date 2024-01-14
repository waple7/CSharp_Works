using System.IO.Compression;
using Backups.Services;

namespace Backups.Entities
{
    public class SplitStorage : IAlgStorage
    {
        public IReadOnlyList<ZipArchive> AddStorage(List<FileProvider> fileProvider, string restorePointNumber, string path)
        {
            var zipFiles = new List<ZipArchive>();
            foreach (FileProvider provider in fileProvider)
            {
                using (var zipToOpen = new FileStream(@"C:\Users\Waple\TestLab3\" + path + provider.FileName + "RestorePoint" + restorePointNumber + ".zip", FileMode.Create))
                {
                    using (var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                    {
                        ZipArchiveEntry readmeEntry = archive.CreateEntry(provider.FileName);
                        zipFiles.Add(archive);
                    }
                }
            }

            return zipFiles;
        }
    }
}