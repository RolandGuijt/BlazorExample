using System.Collections.Generic;
using System.Threading.Tasks;
using RpcApi;

namespace Blazor.Services
{
    public class ConferenceApiService : IConferenceService
    {
        private readonly Conferences.ConferencesClient client;

        public ConferenceApiService(Conferences.ConferencesClient client)
        {
            this.client = client;
        }
        public async Task<IEnumerable<Conference>> GetAll()
        {
            var response = await client.GetAllAsync(
                new GetAllConferencesRequest());
            return response.Conferences;
        }

        public async Task Add(Conference model)
        {
            await client.AddAsync(
                new AddConferenceRequest { Conference = model });
        }
    }
}
