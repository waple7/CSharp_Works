using Backups.Entities;
using Backups.Services;

namespace Backups.Extra
{
    public class MyRepositoryExtra : Repository
    {
        public MyRepositoryExtra(string path)
            : base(path)
        {
            Path = path;
        }

        public void RemoveRestorePoint(BackupExtraService backup, int restorePointNumber, IAlgStorage algorithm)
        {
            if (algorithm is SingleStorage)
            {
                if (File.Exists(@"C:\Users\Waple\TestLab3\Repository" + backup.Path + "ResotorePoint" + backup.RestorePoints[restorePointNumber].RestorePointNumber + ".zip"))
                {
                    File.Delete(@"C:\Users\Waple\TestLab3\Repository" + backup.Path + "ResotorePoint" + backup.RestorePoints[restorePointNumber].RestorePointNumber + ".zip");
                }
            }
            else
            {
                foreach (FileProvider file in backup.RestorePoints[restorePointNumber].FileProvider)
                {
                    if (File.Exists(@"C:\Users\Waple\TestLab3\Repository" + backup.Path + file.FileName + "ResotorePoint" + backup.RestorePoints[restorePointNumber].RestorePointNumber + ".zip"))
                    {
                        File.Delete(@"C:\Users\Waple\TestLab3\Repository" + backup.Path + "ResotorePoint" + backup.RestorePoints[restorePointNumber].RestorePointNumber + ".zip");
                    }
                }
            }

            backup.DeleteRestorePoint(restorePointNumber);
        }

        public void RemoveFile(BackupExtraService backup, RestorePoint restorePoint, FileProvider file)
        {
            if (File.Exists(@"C:\Users\Waple\TestLab3\Repository" + backup.Path + file.FileName + "ResotorePoint" + restorePoint.RestorePointNumber + ".zip"))
            {
                File.Delete(@"C:\Users\Waple\TestLab3\Repository" + backup.Path + file.FileName + "ResotorePoint" + restorePoint.RestorePointNumber + ".zip");
            }

            restorePoint.RemoveFileProvider(file);
        }

        public void RenameFile(BackupExtraService backup, RestorePoint oldRestorePoint, RestorePoint newRestorePoint, FileProvider file)
        {
            string oldName = @"C:\Users\Waple\TestLab3\Repository" + backup.Path + file.FileName + "ResotorePoint" + oldRestorePoint.RestorePointNumber + ".zip";
            string newName = @"C:\Users\Waple\TestLab3\Repository" + backup.Path + file.FileName + "ResotorePoint" + newRestorePoint.RestorePointNumber + ".zip";
            File.Move(oldName, newName);
        }

        public void FileRecovering(FileProvider file)
        {
            File.Create(@"C:\Users\Waple\TestLab3\Repository" + file.FilePath + "/" + file.FileName);
        }

        public void FileRecoveryToPath(FileProvider file, string path)
        {
            File.Create(@"C:\Users\Waple\TestLab3\Repository" + path + "/" + file.FileName);
        }
    }
}
