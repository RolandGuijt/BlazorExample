using System.Collections.Generic;
using System.Linq;

namespace RpcApi.Repositories
{  
    public class ProposalMemoryRepo : IProposalRepo
    {
        private readonly List<Proposal> proposals = new List<Proposal>();

        public ProposalMemoryRepo()
        {
            proposals.Add(new Proposal
            {
                Id = 1,
                ConferenceId = 1,
                Speaker = "Roland Guijt",
                Title = "Understanding ASP.NET Core Security"
            });
            proposals.Add(new Proposal
            {
                Id = 2,
                ConferenceId = 2,
                Speaker = "John Reynolds",
                Title = "Starting Your Developer Career"
            });
            proposals.Add(new Proposal
            {
                Id = 3,
                ConferenceId = 2,
                Speaker = "Stan Lipens",
                Title = "ASP.NET Core TagHelpers"
            });
        }

        public IEnumerable<Proposal> GetAllForConference(int conferenceId)
        {
            return proposals.Where(p => p.ConferenceId == conferenceId);
        }

        public Proposal Add(Proposal model)
        {
            model.Id = proposals.Max(p => p.Id) + 1;
            proposals.Add(model);
            return model;
        }

        public Proposal Approve(int proposalId)
        {
            var proposal = proposals.First(p => p.Id == proposalId);
            proposal.Approved = true;
            return proposal;
        }

        public Proposal GetById(int id)
        {
            return proposals.Single(p => p.Id == id);
        }
    }
}
