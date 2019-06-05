using System.Collections.Generic;
using System.Threading.Tasks;
using Globomantics.Shared.Models;

namespace Blazor.Services
{
    public interface IConferenceService
    {
        Task<IEnumerable<ConferenceModel>> GetAll();
        Task<ConferenceModel> GetById(int id);
        Task<StatisticsModel> GetStatistics();
        Task Add(ConferenceModel model);
    }
}