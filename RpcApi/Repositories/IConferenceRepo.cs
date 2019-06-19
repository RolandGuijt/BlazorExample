using System.Collections.Generic;

namespace RpcApi.Repositories
{
    public interface IConferenceRepo
    {
        Conference Add(Conference model);
        IEnumerable<Conference> GetAll();
    }
}