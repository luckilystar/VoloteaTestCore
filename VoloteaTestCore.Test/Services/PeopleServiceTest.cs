using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoloteaTestCore.Core.Models.People;
using VoloteaTestCore.Repository.People;
using VoloteaTestCore.Service.People;

namespace VoloteaTestCore.Test.Services
{
    public class PeopleServiceTest
    {
        private PeopleService _peopleService;
        [SetUp]
        public void Setup()
        {
            _peopleService = new PeopleService(new PeopleRepository());
        }
        [Test]
        public void GetAllPeople()
        {
            var person = _peopleService.GetAll().FirstOrDefault();
            if (person != null)
            {
                var results = _peopleService.GetAll().Count();
                Assert.That(results, Is.AtLeast(1));
            }
            else
                Assert.Fail("There is no data.");
        }
        [Test]
        public void GetFirstPerson()
        {
            var person = _peopleService.GetAll().FirstOrDefault();
            if (person != null)
            {
                var result = _peopleService.GetById(person.Id);
                Assert.That(person, Is.EqualTo(result));
            }
        }
        [Test]
        public void InsertPerson()
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
            var countBefore = _peopleService.GetAll().Count();
            _peopleService.Insert(p);
            var countAfter = _peopleService.GetAll().Count();
            Assert.That(countAfter, Is.EqualTo(countBefore + 1));
        }

        [Test]
        public void UpdatePerson()
        {
            var person = _peopleService.GetAll().FirstOrDefault();
            if (person != null)
            {
                person.Address = "This is the change of Address";
                _peopleService.Update(person);
                var personAfter = _peopleService.GetById(person.Id);
                Assert.That(person.Address, Is.EqualTo(personAfter.Address));
            }
            else
            {
                Assert.Fail("There is no person data to update.");
            }
        }

        [Test]
        public void DeletePerson()
        {
            var person = _peopleService.GetAll().FirstOrDefault();
            if (person != null)
            {
                _peopleService.Delete(person.Id);
                var personAfter = _peopleService.GetById(person.Id);
                Assert.IsNull(personAfter);
            }
            else
            {
                Assert.Fail("There is no person data to delete.");
            }
        }
    }
}
