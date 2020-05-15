using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TeslaApiExplorer.Models;

namespace TeslaApiExplorer.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> SendAsync(this HttpClient client, HttpMethod method, string url, object content = null, TeslaAuthorization authorization = null)
        {
            var request = new HttpRequestMessage(method, url);
            
            if (authorization != null)
                request.Headers.Authorization = new AuthenticationHeaderValue(authorization.TokenType, authorization.AccessToken);
            
            if (content != null)
                request.Content = new StringContent(JsonSerializer.Serialize(content, new JsonSerializerOptions { IgnoreNullValues = true }), Encoding.UTF8, "application/json");

            return await client.SendAsync(request);
        }
    }
}
