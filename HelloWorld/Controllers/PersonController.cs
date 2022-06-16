using HelloWorld.Business.Dtos;
using HelloWorld.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var personList = _personService.GetPersonList();
            return View(personList);
        }
        [HttpPost]
        public IActionResult PersonSave(PersonDto person)
        {
            _personService.AddPerson(person);
            return RedirectToAction("Index");
        }
    }
}
