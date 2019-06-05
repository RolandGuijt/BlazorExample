using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blazor.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent content)
        {
            var json = await content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
            return JsonSerializer.Parse<T>(json, options);
        }
    }
}
