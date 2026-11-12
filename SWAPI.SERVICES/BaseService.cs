using SWAPI.DATA;
using SWAPI.DOMAIN.Models;
using SWAPI.JSON.JsonModels;
using SWAPI.MAPPER;

namespace SWAPI.SERVICES
{
  public class BaseService<T1, T2> where T1 : BaseJsonModel where T2 : BaseModel
  {
    private readonly MapperService _mapperService;
    private readonly IJsonRepository<T1> _repository;
    public BaseService(MapperService mapperService, IJsonRepository<T1> repository)
    {
      _mapperService = mapperService;
      _repository = repository;
    }
    /// <summary>
    /// Gets all entities asynchronous.
    /// </summary>
    /// <returns>List<T2> the entities.</returns>
    public async Task<List<T2>> GetAllEntitiesAsync()
    {
      var entities = (await _repository.GetEntitiesAsync()).Select(e => _mapperService.Map<T1, T2>(e)).ToList();
      return entities;
    }
    /// <summary>
    /// Gets the entity by identifier asynchronous.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Entity of type T2.</returns>
    public async Task<T2> GetEntityByIdAsync(int id)
    {
      var entityJson = await _repository.GetByIdAsync(id);
      if (entityJson == null)
      {
        return default(T2);
      }
      var entity = _mapperService.Map<T1, T2>(entityJson);
      return entity;
    }
    /// <summary>
    /// Gets the entities by identifiers asynchronous.
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>List<T2> the entities.</returns>
    public async Task<List<T2>> GetEntitiesByIdsAsync(List<int> ids)
    {
      var entitiesJson = await _repository.GetEntitiesByIdsAsync(ids);
      var entities = entitiesJson.Select(e => _mapperService.Map<T1, T2>(e)).ToList();
      return entities;
    }
    /// <summary>
    /// Gets the relations identifiers asynchronous.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="relationPropertyName"></param>
    /// <returns>List<int> the identifiers.</returns>
    public async Task<List<int>> GetRelationsIdsAsync(T2 entity, string relationPropertyName)
    {
      return await _repository.RelationsIdsAsync(entity.Id, relationPropertyName);
    }
  }
}