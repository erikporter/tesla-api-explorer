namespace TeslaApiExplorer.Models
{
    public class TeslaApiResult<T>
    {
        public T Content { get; set; }

        public string Error { get; set; }
    }
}
