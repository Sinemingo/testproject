using HelloWorld.Business.Dtos;
using HelloWorld.Business.Services.Abstract;
using HelloWorld.Cache;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IMemoryCacheProviderService _memoryCacheProviderService;

        public PersonController(IPersonService personService, IMemoryCacheProviderService memoryCacheProviderService)
        {
            _personService = personService;
            _memoryCacheProviderService = memoryCacheProviderService;   
        }
        [HttpGet]
        public IActionResult Index()
        {
            var personList =_memoryCacheProviderService.GetPersonList();
            return View(personList);
        }
        [HttpPost]
        public IActionResult PersonSave(PersonDto person)
        {
            if (ModelState.IsValid)
            {
            _personService.AddPerson(person);
            }
            return RedirectToAction("Index");
        }
    }
}
