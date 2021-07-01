using System;
using System.Collections.Generic;
using System.Linq;
using Google.Protobuf.WellKnownTypes;

namespace RpcApi.Repositories
{
    public class ConferenceMemoryRepo : IConferenceRepo
    {
        private readonly List<Conference> conferences = new List<Conference>();

        public ConferenceMemoryRepo()
        {
            conferences.Add(new Conference { Id = 1, Name = "DWX", Location = "Nuremberg", Start = Timestamp.FromDateTime(new DateTime(2020, 2, 26).ToUniversalTime()), AttendeeTotal = 900 });
            conferences.Add(new Conference { Id = 2, Name = "DevFest", Location = "Orlando", Start = Timestamp.FromDateTime(new DateTime(2020, 11, 22).ToUniversalTime()), AttendeeTotal = 3210 });
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
