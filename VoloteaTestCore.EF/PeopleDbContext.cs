using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoloteaTestCore.Core.Models.People;

namespace VoloteaTestCore.EF
{
    public class PeopleDbContext:DbContext
    {
        public PeopleDbContext()
        {

        }
        public DbSet<Person> People { get; set; }
    }
}
