using SWAPI.DATA;
using SWAPI.DOMAIN.Models;
using SWAPI.JSON.JsonModels;
using SWAPI.MAPPER;
//
namespace SWAPI.SERVICES
{
  public class PersonService : BaseService<PersonJson, Person>
  {
    private readonly ILogger<PersonService> _logger;
    public PersonService(ILogger<PersonService> logger, IJsonRepository<PersonJson> repository, MapperService mapperService)
    : base(mapperService, repository)
    {
      _logger = logger;
    }
    /// <summary>
    /// Gets all persons asynchronous.
    /// </summary>
    /// <returns></returns>
    public async Task<ServiceOperationResult<List<Person>>> GetAllPersonsAsync()
    {
      return ServiceOperationResult<List<Person>>.Ok(await GetAllEntitiesAsync());
    }
    /// <summary>
    /// Gets the person by identifier asynchronous.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ServiceOperationResult<Person>> GetPersonByIdAsync(int id)
    {
      var person = await GetEntityByIdAsync(id);
      if (person == null)
      {
        return ServiceOperationResult<Person>.NotFound<Person>($"Person with ID {id} not found.");
      }
      return ServiceOperationResult<Person>.Ok(person);
    }
  }
}