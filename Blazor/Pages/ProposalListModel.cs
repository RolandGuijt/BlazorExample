using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Services;
using Microsoft.AspNetCore.Components;
using RpcApi;

namespace Blazor.Pages
{
    public class ProposalListModel: ComponentBase
    {
        [Parameter]
        public string ConferenceId { get; set; }

        public IEnumerable<Proposal> proposals;

        [Inject]
        protected IProposalService ProposalService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            proposals = await ProposalService.GetAll(int.Parse(ConferenceId));
        }
    }
}
