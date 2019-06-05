using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Globomantics.Shared.Models;

namespace API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class StatisticsController: ControllerBase
    {
        private readonly IStatisticsRepo repo;

        public StatisticsController(IStatisticsRepo repo)
        {
            this.repo = repo;
        }
        public StatisticsModel Get()
        {
            return repo.GetStatistics();
        }
    }
}
