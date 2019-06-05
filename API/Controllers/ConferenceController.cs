using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Globomantics.Shared.Models;
using System.Linq;

namespace API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ConferenceController: ControllerBase
    {
        private readonly IConferenceRepo repo;

        public ConferenceController(IConferenceRepo repo)
        {
            this.repo = repo;
        }

        public IActionResult GetAll()
        {
            var conferences = repo.GetAll();
            if (!conferences.Any())
                return new NoContentResult();

            return new ObjectResult(conferences);
        }

        [HttpPost]
        public ConferenceModel Add(ConferenceModel conference)
        {
            return repo.Add(conference);
        }
    }
}
