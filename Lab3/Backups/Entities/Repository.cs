namespace Backups.Entities
{
    public class Repository
    {
        public Repository(string path)
        {
            Path = path;
        }

        public string Path { get; set; }
    }
}
