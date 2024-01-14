using Backups.Entities;
using Backups.Services;
using Xunit;

namespace Backups.Test
{
    public class BackupServiceTests
    {
        [Fact]
        public void SplitAlgorythmStorage()
        {
            IAlgStorage algorithm = new SplitStorage();
            var backupTask = new BackupTask("RepositoryBand", algorithm);
            string pathFile = "someRepository";
            int restorePoint1 = 1;
            int restorePoint2 = 2;
            backupTask.Add(pathFile, "A");
            backupTask.Add(pathFile, "B");
            backupTask.RestorePoint();
            Assert.Equal(2, backupTask.CheckStorage(restorePoint1));
            backupTask.Remove(pathFile, "B");
            backupTask.RestorePoint();
            Assert.Equal(2, backupTask.RestorePoints.Count);
            Assert.Equal(1, backupTask.CheckStorage(restorePoint2));
        }

        [Fact]
        public void SingleAlgorythmStorage()
        {
            IAlgStorage algorithm = new SingleStorage();
            var backupTask = new BackupTask("RepositoryBand", algorithm);
            string pathFile = "someRepository";
            int restorePoint1 = 1;
            int restorePoint2 = 2;
            backupTask.Add(pathFile, "A");
            backupTask.Add(pathFile, "B");
            backupTask.RestorePoint();
            Assert.Equal(1, backupTask.CheckStorage(restorePoint1));
            backupTask.Remove(pathFile, "B");
            backupTask.RestorePoint();
            Assert.Equal(2, backupTask.RestorePoints.Count);
            Assert.Equal(1, backupTask.CheckStorage(restorePoint2));
        }
    }
}
