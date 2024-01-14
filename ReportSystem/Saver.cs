using Newtonsoft.Json;
using ReportSystem.DataAccesslayer;

namespace ReportSystem
{
    public class Saver
    {
        public void Save(RepositoryMessages recordService, string fileSave)
        {
            string json = JsonConvert.SerializeObject(recordService, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            });
            File.WriteAllText(fileSave, json);
        }

        public RepositoryMessages? RecoverMessages(string file)
        {
            string json = File.ReadAllText(file);
            return JsonConvert.DeserializeObject<RepositoryMessages>(json);
        }

        public void Save(RepositoryRecord recordService, string fileSave)
        {
            string json = JsonConvert.SerializeObject(recordService, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            });
            File.WriteAllText(fileSave, json);
        }

        public RepositoryRecord? RecoverRecord(string file)
        {
            string json = File.ReadAllText(file);
            return JsonConvert.DeserializeObject<RepositoryRecord>(json);
        }

        public void Save(RepositoryWorker recordService, string fileSave)
        {
            string json = JsonConvert.SerializeObject(recordService, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            });
            File.WriteAllText(fileSave, json);
        }

        public RepositoryWorker? RecoverWorker(string file)
        {
            string json = File.ReadAllText(file);
            return JsonConvert.DeserializeObject<RepositoryWorker>(json);
        }
    }
}