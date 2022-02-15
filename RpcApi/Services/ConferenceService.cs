using System.Threading.Tasks;
using Grpc.Core;
using RpcApi.Repositories;

namespace RpcApi.Services
{
    public class ConferenceService: Conferences.ConferencesBase
    {
        private readonly IConferenceRepo repo;

        public ConferenceService(IConferenceRepo repo)
        {
            this.repo = repo;
        }

        public override Task<GetAllConferencesResponse> GetAll(
            GetAllConferencesRequest request, ServerCallContext context)
        {
            var result = new GetAllConferencesResponse();
            result.Conferences.Add(repo.GetAll());
            return Task.FromResult(result);
        }
    }
}
