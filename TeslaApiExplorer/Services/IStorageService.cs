using System.Threading.Tasks;

namespace TeslaApiExplorer.Services
{
    public interface IStorageService
    {
        Task<T> GetAsync<T>(string key) where T : class;
        Task SaveAsync<T>(string key, T value);
    }
}