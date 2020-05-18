using System.Threading.Tasks;

namespace TeslaApiExplorer.Services
{
    public interface IStorageService
    {
        T Get<T>(string key) where T : class;
        void Save<T>(string key, T value);
    }
}