using Backups.Entities;

namespace Backups.Extra.Merge
{
    public class MergeRestorePoint
    {
        public MergeRestorePoint(BackupExtraService backupExtraService)
        {
            BackupExtraService = backupExtraService;
        }

        public BackupExtraService BackupExtraService { get; set; }

        public void Merge()
        {
            if (BackupExtraService.AlgStorage is SingleStorage)
            {
                BackupExtraService.DeleteRestorePoint(BackupExtraService.RestorePoints.Count - 2);
            }
            else
            {
                var filesDelete = new List<FileProvider>();
                var filesSwap = new List<FileProvider>();
                foreach (FileProvider file in BackupExtraService.RestorePoints[^2].FileProvider)
                {
                    if (BackupExtraService.RestorePoints[^1].FileProvider.Contains(file))
                    {
                        filesDelete.Add(file);
                    }
                    else
                    {
                        BackupExtraService.RestorePoints[^1].AddFileProvider(file);
                        BackupExtraService.RestorePoints[^2].RemoveFileProvider(file);
                        filesSwap.Add(file);
                    }
                }

                foreach (FileProvider file in filesDelete)
                {
                    BackupExtraService.RepositoryService.RemoveFile(BackupExtraService, BackupExtraService.RestorePoints[^2], file);
                }

                foreach (FileProvider file in filesSwap)
                {
                    BackupExtraService.RepositoryService.RenameFile(BackupExtraService, BackupExtraService.RestorePoints[^2], BackupExtraService.RestorePoints[^1], file);
                }

                BackupExtraService.DeleteRestorePoint(BackupExtraService.RestorePoints.Count - 2);
            }

            BackupExtraService.Logging.Log("merge restore points");
        }
    }
}
