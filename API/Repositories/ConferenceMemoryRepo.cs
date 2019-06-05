using System;
using System.Collections.Generic;
using System.Linq;
using Globomantics.Shared.Models;

namespace API.Repositories
{
    public class ConferenceMemoryRepo : IConferenceRepo
    {
        private readonly List<ConferenceModel> conferences = new List<ConferenceModel>();

        public ConferenceMemoryRepo()
        {
            conferences.Add(new ConferenceModel { Id = 1, Name = "NDC", Location = "Oslo", Start = new DateTime(2017, 6, 12), AttendeeTotal = 2132});
            conferences.Add(new ConferenceModel { Id = 2, Name = "IT/DevConnections", Location = "San Francisco", Start = new DateTime(2017, 10, 18), AttendeeTotal = 3210});
        }
        public IEnumerable<ConferenceModel> GetAll()
        {
            return conferences;
        }

        public ConferenceModel GetById(int id)
        {
            return conferences.First(c => c.Id == id);
        }

        public ConferenceModel Add(ConferenceModel model)
        {
            model.Id = conferences.Max(c => c.Id) + 1;
            conferences.Add(model);
            return model;
        }
    }
}
