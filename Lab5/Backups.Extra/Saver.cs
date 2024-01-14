using Newtonsoft.Json;

namespace Backups.Extra
{
    public class Saver
    {
        public void Save(BackupExtraService backup, string fileSave)
        {
            string json = JsonConvert.SerializeObject(backup, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            });
            File.WriteAllText(fileSave, json);
        }

        public BackupExtraService Recover(string file)
        {
            string json = File.ReadAllText(file);
            return JsonConvert.DeserializeObject<BackupExtraService>(json);
        }
    }
}
