using System.Collections.Generic;
using System.Threading.Tasks;
using RpcApi;

namespace Blazor.Services
{
    public interface IProposalService
    {
        Task Add(Proposal model);
        Task<Proposal> Approve(int proposalId);
        Task<IEnumerable<Proposal>> GetAll(int conferenceId);
    }
}