using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RpcApi.Repositories
{
    public class ConferenceMemoryRepo : IConferenceRepo
    {
        private readonly List<Conference> conferences = new List<Conference>();

        public ConferenceMemoryRepo()
        {
            conferences.Add(new Conference { Id = 1, Name = "NDC", Location = "Oslo", Start = Timestamp.FromDateTime(new DateTime(2017, 6, 12).ToUniversalTime()), AttendeeTotal = 2132});
            conferences.Add(new Conference { Id = 2, Name = "IT/DevConnections", Location = "San Francisco", Start = Timestamp.FromDateTime(new DateTime(2017, 10, 18).ToUniversalTime()), AttendeeTotal = 3210});
        }
        public IEnumerable<Conference> GetAll()
        {
            return conferences;
        }

        public Conference Add(Conference model)
        {
            model.Id = conferences.Max(c => c.Id) + 1;
            conferences.Add(model);
            return model;
        }
    }
}
