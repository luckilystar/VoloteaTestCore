using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoloteaTestCore.Core.Models.People;
using VoloteaTestCore.Repository.People;

namespace VoloteaTestCore.Test.Repositories
{
    public class PeopleRepositoryTest
    {
        private PeopleRepository _peopleRepository;
        [SetUp]
        public void Setup()
        {
            _peopleRepository = new PeopleRepository();
        }

        [Test]
        public void GetAllPeople()
        {
            var person = _peopleRepository.GetAll().FirstOrDefault();
            if (person!=null)
            {
                var results = _peopleRepository.GetAll().Count();
                Assert.That(results, Is.AtLeast(1));
            }
            else
                Assert.Fail("There is no data.");
        }
        [Test]
        public void GetFirstPerson()
        {
            var person = _peopleRepository.GetAll().FirstOrDefault();
            if (person != null)
            {
                var result = _peopleRepository.GetById(person.Id);
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
            var countBefore = _peopleRepository.GetAll().Count();
            _peopleRepository.Insert(p);
            _peopleRepository.Save();
            var countAfter = _peopleRepository.GetAll().Count();
            Assert.That(countAfter, Is.EqualTo(countBefore + 1));
        }

        [Test]
        public void UpdatePerson()
        {
            var person = _peopleRepository.GetAll().FirstOrDefault();
            if (person != null)
            {
                person.Address = "This is the change of Address";
                _peopleRepository.Update(person);
                _peopleRepository.Save();
                var personAfter = _peopleRepository.GetById(person.Id);
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
            var person = _peopleRepository.GetAll().FirstOrDefault();
            if (person != null)
            {
                _peopleRepository.Delete(person.Id);
                _peopleRepository.Save();
                var personAfter = _peopleRepository.GetById(person.Id);
                Assert.IsNull(personAfter);
            }
            else
            {
                Assert.Fail("There is no person data to delete.");
            }
        }
    }
}
