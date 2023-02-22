using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoloteaTestCore.Core.Models.People;
using VoloteaTestCore.Repository.People;
using VoloteaTestCore.Service.People;
using VoloteaTestCore.WebApi.Controllers;

namespace VoloteaTestCore.Test.Controllers
{
    public class PeopleControllerTest
    {
        private TestDatabaseFixture _fixture { get; set; }
        private PeopleController _controller;
        [SetUp]
        public void Setup()
        {
            _fixture = new TestDatabaseFixture();
            var context = _fixture.CreateContext();
            _controller = new PeopleController(new PeopleService(new PeopleRepository(context)));
        }
        [Test]
        public void Get()
        {
            IEnumerable<Person> result = _controller.Get();
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetById()
        {
            var person = _controller.Get().FirstOrDefault();
            if (person != null)
            {
                var result = _controller.Get(person.Id);
                Assert.That(result, Is.EqualTo(person));
            }
            else
                Assert.Fail("There is no data to get.");
        }

        [Test]
        public void Post()
        {
            Person p = new Person
            {
                Address = "Address 1",
                Birthday = DateTime.Today.AddYears(-19),
                Email = "address@gmail.com",
                FirstName = "Name 1",
                LastName = "Last Name 1",
                PhoneNumber = "12345678"
            };

            var countBefore = _controller.Get().Count();
            _controller.Post(p);
            var countAfter = _controller.Get().Count();

            Assert.That(countAfter, Is.EqualTo(countBefore + 1));
        }

        [Test]
        public void Put()
        {
            var person = _controller.Get().FirstOrDefault();
            if (person != null)
            {
                person.Address = "Change To New Address";
                _controller.Put(person);
                var personAfter = _controller.Get(person.Id);
                Assert.That(personAfter.Address, Is.EqualTo(person.Address));
            }
            else
                Assert.Fail("There is no data to update.");
        }

        [Test]
        public void Delete()
        {
            var person = _controller.Get().FirstOrDefault();
            if (person != null)
            {
                _controller.Delete(person.Id);
                var result = _controller.Get(person.Id);
                Assert.IsNull(result);
            }
            else
                Assert.Fail("There is no data to delete.");
        }
    }
}
