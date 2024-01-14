namespace Backups.Extra.Recover
{
    public class Recovering
    {
        public Recovering(BackupExtraService backupExtraService)
        {
            BackupExtraService = backupExtraService;
        }

        public BackupExtraService BackupExtraService { get; set; }

        public void Recover(FileProvider file)
        {
            BackupExtraService.RepositoryService.FileRecovering(file);
            BackupExtraService.Logging.Log("the file restored");
        }

        public void RecoveringToThePath(FileProvider file, string path)
        {
            BackupExtraService.RepositoryService.FileRecoveryToPath(file, path);
            BackupExtraService.Logging.Log("the file restored to the path");
        }
    }
}
