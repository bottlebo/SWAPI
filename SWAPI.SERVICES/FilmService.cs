using SWAPI.DATA;
using SWAPI.DOMAIN.Models;
using SWAPI.JSON.JsonModels;
using SWAPI.MAPPER;
//
namespace SWAPI.SERVICES
{
  public class FilmService : BaseService<FilmJson, Film>
  {
    private readonly ILogger<FilmService> _logger;
    private readonly PersonService _personService;
    public FilmService(PersonService personService, ILogger<FilmService> logger, IJsonRepository<FilmJson> repository, MapperService mapperService)
    : base(mapperService, repository)
    {
      _logger = logger;
      _personService = personService;
    }
    /// <summary>
    /// Gets all films asynchronous.
    /// </summary>
    /// <returns></returns>
    public async Task<ServiceOperationResult<List<Film>>> GetAllFilmsAsync()
    {
      return ServiceOperationResult<List<Film>>.Ok(await GetAllEntitiesAsync());
    }
    /// <summary>
    /// Gets the film by identifier asynchronous. 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ServiceOperationResult<Film>> GetFilmByIdAsync(int id)
    {
      var film = await GetEntityByIdAsync(id);
      if (film == null)
      {
        return ServiceOperationResult<Film>.NotFound<Film>($"Film with ID {id} not found.");
      }
      return ServiceOperationResult<Film>.Ok(film);
    }
    /// <summary>
    /// Gets the film by title asynchronous.
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    public async Task<ServiceOperationResult<Film>> GetFilmByTitleAsync(string title)
    {
      var films = await GetAllEntitiesAsync();
      var film = films.FirstOrDefault(f => f.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
      if (film == null)
      {
        return ServiceOperationResult<Film>.NotFound<Film>($"Film with title '{title}' not found.");
      }
      return ServiceOperationResult<Film>.Ok(film);
    }
    /// <summary>
    /// Gets the characters by film identifier asynchronous.
    /// </summary>
    /// <param name="filmId"></param>
    /// <returns></returns>
    public async Task<ServiceOperationResult<List<Person>>> GetCharactersByFilmIdAsync(int filmId)
    {
      var film = await GetEntityByIdAsync(filmId);
      if (film == null)
      {
        return ServiceOperationResult<List<Person>>.NotFound<List<Person>>($"Film with ID {filmId} not found.");
      }

      var characterIds = await GetRelationsIdsAsync(film, nameof(FilmJson.Characters));
      var characters = await _personService.GetEntitiesByIdsAsync(characterIds);
      return ServiceOperationResult<List<Person>>.Ok(characters.ToList());
    }
    public async Task<ServiceOperationResult<Film>> GetFilmWithCharacters(int filmId)
    {
      var film = await GetEntityByIdAsync(filmId);
      if (film == null)
      {
        return ServiceOperationResult<Film>.NotFound<Film>($"Film with ID {filmId} not found.");
      }

      var characterIds = await GetRelationsIdsAsync(film, nameof(FilmJson.Characters));
      var characters = await _personService.GetEntitiesByIdsAsync(characterIds);
      film.Characters = characters;

      // Assuming you want to return the film along with its characters
      // You might want to create a new model that includes both Film and its Characters
      // For now, I'm returning just the film in a list for demonstration purposes
      return ServiceOperationResult<List<Film>>.Ok(film);
    }
  }
}