using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace TeslaApiExplorer.Services
{
    public class FileStorageService : IStorageService
    {
        public async Task<T> GetAsync<T>(string key) where T : class
        {
            if (!File.Exists(key))
                return null;

            using Stream stream = File.OpenRead(key);
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }

        public async Task SaveAsync<T>(string key, T value)
        {
            if (File.Exists(key))
                File.Delete(key);

            await File.WriteAllTextAsync(key, JsonSerializer.Serialize(value));
        }
    }
}
