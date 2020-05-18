using System.IO;
using System.Text.Json;

namespace TeslaApiExplorer.Services
{
    public class FileStorageService : IStorageService
    {
        public T Get<T>(string key) where T : class
        {
            if (!File.Exists(key))
                return null;

            var text = File.ReadAllText(key);
            return JsonSerializer.Deserialize<T>(text);
        }

        public void Save<T>(string key, T value)
        {
            if (File.Exists(key))
                File.Delete(key);

            File.WriteAllText(key, JsonSerializer.Serialize(value));
        }
    }
}
