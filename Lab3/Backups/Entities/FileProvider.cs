namespace Backups
{
    public class FileProvider
    {
        public FileProvider(string filePath, string fileName)
        {
            FilePath = filePath ?? string.Empty;
            FileName = fileName ?? string.Empty;
        }

        public string FilePath { get; set; }
        public string FileName { get; set; }
    }
}
