using System.Collections.Generic;
using System.Threading.Tasks;
using RpcApi;

namespace Blazor.Services
{
    public interface IConferenceService
    {
        Task<IEnumerable<Conference>> GetAll();
        Task Add(Conference model);
    }
}