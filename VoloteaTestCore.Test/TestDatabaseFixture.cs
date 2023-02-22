using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using VoloteaTestCore.Core.Models.People;
using VoloteaTestCore.EF;

namespace VoloteaTestCore.Test
{
    [TestFixture]
    public class TestDatabaseFixture
    {
        private const string ConnectionString = @"Data Source=.; Initial Catalog=PeopleCoreDb; Integrated Security=True;TrustServerCertificate=True;";

        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public TestDatabaseFixture()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                        context.AddRange(
                        new Person
                        {
                            Address = "Address 1",
                            Birthday = DateTime.Today.AddYears(-19),
                            Email = "address@gmail.com",
                            FirstName = "Name 1",
                            LastName = "Last Name 1",
                            PhoneNumber = "12345678"
                        },
                        new Person
                        {
                            Address = "Address 2",
                            Birthday = DateTime.Today.AddYears(-19),
                            Email = "address@gmail.com",
                            FirstName = "Name 2",
                            LastName = "Last Name 2",
                            PhoneNumber = "87654321"
                        });
                        context.SaveChanges();
                    }

                    _databaseInitialized = true;
                }
            }
        }

        public PeopleDbContext CreateContext()
            => new PeopleDbContext(
                new DbContextOptionsBuilder<PeopleDbContext>()
                    .UseSqlServer(ConnectionString)
                    .Options);
    }
}
