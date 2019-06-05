using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blazor.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task PostAsJsonAsync<T>(this HttpClient httpClient, string url, T theObject)
        {
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.ToString(theObject, options);
            await httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
        }
    }
}
