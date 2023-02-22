using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoloteaTestCore.Core.Models.People;

namespace VoloteaTestCore.EF
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext() : base()
        {

        }
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options)
        : base(options)
        {
        }
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }
    }
}
