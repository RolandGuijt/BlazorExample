using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Globomantics.Shared.Models;
using System.Linq;
using System;

namespace API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ProposalController: ControllerBase
    {

        private readonly IProposalRepo proposalRepo;

        public ProposalController(IProposalRepo proposalRepo)
        {
            this.proposalRepo = proposalRepo;
        }

        [HttpGet("{conferenceId}")]
        public IActionResult GetAll(int conferenceId)
        {
            var proposals = proposalRepo.GetAllForConference(conferenceId);
           
            if (!proposals.Any())
                return new NoContentResult();
            return new ObjectResult(proposals);
        }

        [HttpGet("{id}", Name = "GetById")]
        public ProposalModel GetById(int id)
        {
            return proposalRepo.GetById(id);
        }

        [HttpPost]
        public IActionResult Add([FromBody]ProposalModel model)
        {
            var addedProposal = proposalRepo.Add(model);
            return CreatedAtRoute("GetById", new { id = addedProposal.Id }, 
                addedProposal);            
        }

        [HttpPut("{proposalId}")]
        public IActionResult Approve(int proposalId)
        {
            try
            {
                return new ObjectResult(proposalRepo.Approve(proposalId));
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}
