using Backups.Entities;
using Backups.Extra.DeleteRestorePoint;
using Backups.Extra.Logging;
using Backups.Extra.Merge;
using Backups.Services;
using Xunit;

namespace Backups.Extra.Test
{
    public class BackupsExtraTest
    {
        [Fact]
        public void CheckNumberLimits()
        {
            IAlgStorage algorithm = new SingleStorage();
            var backupTask = new BackupExtraService("RepositoryBand", algorithm, new ConsoleLogger());
            string pathFile = "someRepository";
            DateTime dateTimeLimit = DateTime.Now;
            backupTask.Add(pathFile, "A");
            backupTask.Add(pathFile, "B");
            backupTask.RestorePoint();
            backupTask.Remove(pathFile, "B");
            backupTask.RestorePoint();
            var limitNumberRestorePoint = new LimitNumberRestorePoint(backupTask, 1, algorithm, dateTimeLimit);
            limitNumberRestorePoint.GetLimitAndDelete();
            int newNumberOfRestorePoints = 1;
            Assert.True(newNumberOfRestorePoints == backupTask.RestorePoints.Count);
        }

        [Fact]
        public void Merge()
        {
            IAlgStorage algorithm = new SingleStorage();
            var backupTask = new BackupExtraService("RepositoryBand", algorithm, new ConsoleLogger());
            string pathFile = "someRepository";
            backupTask.Add(pathFile, "A");
            backupTask.Add(pathFile, "B");
            backupTask.RestorePoint();
            backupTask.Remove(pathFile, "B");
            backupTask.MakeRestorePointExtra();
            var merge = new MergeRestorePoint(backupTask);
            merge.Merge();
            Assert.True(backupTask.RestorePoints.Count == 1);
            Assert.False(backupTask.CheckFile(1, "RepositoryBand/ARestorePoint1.zip"));
        }

        [Fact]
        public void CheckTimeLimits()
        {
            IAlgStorage algorithm = new SingleStorage();
            var backupTask = new BackupExtraService("RepositoryBand", algorithm, new ConsoleLogger());
            string pathFile = "someRepository";
            backupTask.Add(pathFile, "A");
            backupTask.Add(pathFile, "B");
            backupTask.RestorePoint();

            DateTime dateTimeLimit = DateTime.Now;
            backupTask.RemoveFile(pathFile, "B");
            var limitTimeRestorePoint = new LimitTimeRestorePoint(backupTask, 1, algorithm, dateTimeLimit);
            limitTimeRestorePoint.GetLimitAndDelete();
            backupTask.MakeRestorePointExtra();
            int newNumberOfRestorePoints = 1;
            Assert.True(newNumberOfRestorePoints == backupTask.RestorePoints.Count);
        }
    }
}
