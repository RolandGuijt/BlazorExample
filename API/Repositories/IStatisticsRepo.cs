using Globomantics.Shared.Models;

namespace API.Repositories
{
    public interface IStatisticsRepo
    {
        StatisticsModel GetStatistics();
    }
}