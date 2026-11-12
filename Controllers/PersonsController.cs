using Microsoft.AspNetCore.Mvc;
using SWAPI.SERVICES;
namespace SWAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PersonsController : ControllerBase
  {
    private readonly PersonService _personService;

    public PersonsController(PersonService personService)
    {
      _personService = personService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPersons()
    {
      return this.FromServiceOperationResult(
         await _personService.GetAllPersonsAsync()
      );
    }
     [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonById([FromRoute] int id)
        {
            return this.FromServiceOperationResult(
            await _personService.GetPersonByIdAsync(id)
            );

        }
  }
}