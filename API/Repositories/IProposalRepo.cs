using System.Collections.Generic;
using Globomantics.Shared.Models;

namespace API.Repositories
{
    public interface IProposalRepo
    {
        ProposalModel Add(ProposalModel model);
        ProposalModel Approve(int proposalId);
        IEnumerable<ProposalModel> GetAllForConference(int conferenceId);
        ProposalModel GetById(int id);
    }
}