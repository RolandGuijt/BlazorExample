using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Globomantics.Shared.Models;
using Blazor.Extensions;

namespace Blazor.Services
{
    public class ConferenceApiService : IConferenceService
    {
        private readonly HttpClient client;

        public ConferenceApiService(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient("GlobomanticsApi");
        }
        public async Task<IEnumerable<ConferenceModel>> GetAll()
        {
            List<ConferenceModel> result;
            var response = await client.GetAsync("/v1/Conference");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<List<ConferenceModel>>();
            else
                throw new HttpRequestException(response.ReasonPhrase);

            return result;
        }

        public async Task<ConferenceModel> GetById(int id)
        {
            var result = new ConferenceModel();
            var response = await client.GetAsync($"/v1/Conference/{id}");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<ConferenceModel>();

            return result;
        }

        public async Task<StatisticsModel> GetStatistics()
        {
            var result = new StatisticsModel();
            var response = await client.GetAsync($"/v1/Statistics");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<StatisticsModel>();

            return result;
        }

        public async Task Add(ConferenceModel model)
        {
            await client.PostAsJsonAsync("/v1/Conference", model);
        }
    }
}
