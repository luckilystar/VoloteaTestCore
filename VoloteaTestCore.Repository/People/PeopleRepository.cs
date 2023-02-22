using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoloteaTestCore.Core.Models.People;
using VoloteaTestCore.EF;

namespace VoloteaTestCore.Repository.People
{
    public class PeopleRepository : GenericRepository<Person>, IPeopleRepository
    {
        public PeopleRepository() : base()
        {

        }
        public PeopleRepository(PeopleDbContext context)
          : base(context)
        {

        }
    }
}
