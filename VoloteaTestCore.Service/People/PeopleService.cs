using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoloteaTestCore.Core.Models.People;
using VoloteaTestCore.Repository.People;

namespace VoloteaTestCore.Service.People
{
    public class PeopleService : GenericService<Person>, IPeopleService
    {
        public IPeopleRepository _peopleRepository;
        public PeopleService(IPeopleRepository peopleRepository)
            : base(peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }
    }
}
