using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RpcApi;
using Grpc.Net.Client;

namespace Blazor.Services
{  
    public class ProposalApiService : IProposalService
    {
        private readonly Proposals.ProposalsClient client;

        public ProposalApiService(IHttpClientFactory httpClientFactory)
        {
            var httpClient = httpClientFactory.CreateClient("GlobomanticsGrpc");
            client = GrpcClient.Create<Proposals.ProposalsClient>(httpClient);
        }

        public async Task<IEnumerable<Proposal>> GetAll(int conferenceId)
        {
            var result = await client.GetAllAsync(new GetAllProposalsRequest { ConferenceId = conferenceId });
            return result.Proposals;
        }

        public async Task Add(Proposal proposal)
        {
            await client.AddAsync(new AddProposalRequest { Proposal = proposal });
        }

        public async Task<Proposal> Approve(int proposalId)
        {
            var response = await client.ApproveAsync(new ApproveRequest { Id = proposalId });
            return response.Proposal;
        }
    }
}
