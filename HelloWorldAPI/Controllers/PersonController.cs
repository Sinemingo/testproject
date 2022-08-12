using HelloWorld.Business.Dtos;
using HelloWorld.Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HelloWorldAPI.Controllers
{
    [Route("api/persons")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public IActionResult AddPerson(PersonDto personDto)
        {
            _personService.AddPerson(personDto);
             return NoContent();
        }
        [HttpGet]
        public IActionResult GetPersonList()
        {
            var personList=_personService.GetPersonList();
            return Ok(personList);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetPersonById(int id)
        {
            var person = _personService.GetPersonById(id);
            return Ok(person);
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeletePersonById(int id)
        {
            var result = _personService.DeletePersonById(id);
            return NoContent();
        }

    }
}
