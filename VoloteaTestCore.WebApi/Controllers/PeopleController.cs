using Microsoft.AspNetCore.Mvc;
using VoloteaTestCore.Core.Models.People;
using VoloteaTestCore.Service.People;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VoloteaTestCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;
        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }
        // GET: api/<PeopleController>
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _peopleService.GetAll();
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return _peopleService.GetById(id);
        }

        // POST api/<PeopleController>
        [HttpPost]
        public void Post([FromBody] Person person)
        {
            _peopleService.Insert(person);
        }

        // PUT api/<PeopleController>/5
        [HttpPut]
        public void Put([FromBody] Person person)
        {
            _peopleService.Update(person);
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _peopleService.Delete(id);
        }
    }
}
