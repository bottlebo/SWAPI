using SWAPI.JSON.JsonModels;
using SWAPI.DATA;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SWAPI.DATA
{
  public class Repository<T> : IJsonRepository<T> where T : BaseJsonModel
  {
    private readonly IDataService _dataService;
    private T entity = Activator.CreateInstance<T>();
    private const string api = "https://swapi.dev/api/";
    public Repository(IDataService dataService)
    {
      _dataService = dataService;
    }
    /// <summary>
    /// Gets the entity by identifier asynchronous.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<T> GetByIdAsync(int id)
    {
      string path = entity.GetPath();
      var url = $"{api}{path}/{id}/";
      var entityList = await GetEntitiesAsync();

      var result = entityList.FirstOrDefault(e => e.Url == url);
      return result;
    }
    /// <summary>
    /// Gets entities asynchronous.
    /// </summary>
    /// <returns></returns>
    public async Task<ICollection<T>> GetEntitiesAsync()
    {
      string path = entity.GetPath();
      string jsonString = await _dataService.GetDataResultAsync(path);
      var jObject = (JObject)JsonConvert.DeserializeObject(jsonString);
      if (jsonString == null)
      {
        return null;
      }
      var jArray = (JArray)jObject["results"];
      var results = jArray.ToString();
      var entityList = JsonConvert.DeserializeObject<List<T>>(results);
      return entityList;
    }
    /// <summary>
    /// Gets the entity by URL asynchronous.
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public async Task<T> GetEntityByUrlAsync(string url)
    {
      var entityList = await GetEntitiesAsync();
      var result = entityList.FirstOrDefault(e => e.Url == url);
      return result;
    }
    /// <summary>
    /// Gets entities by URLs asynchronous.
    /// </summary>
    /// <param name="urls"></param>
    /// <returns></returns>
    public async Task<ICollection<T>> GetEntitiesByUrlsAsync(List<string> urls)
    {
      var entityList = await GetEntitiesAsync();
      var results = entityList.Where(e => urls.Contains(e.Url)).ToList();
      return results;
    }
    /// <summary>
    /// Gets entities by IDs asynchronous.
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public async Task<ICollection<T>> GetEntitiesByIdsAsync(List<int> ids)
    {
      var entityList = await GetEntitiesAsync();
      var results = entityList.Where(e => ids.Contains(e.GetIdFromUrl())).ToList();
      return results;
    }
    /// <summary>
    /// Gets the relations identifiers asynchronous.
    /// </summary>
    /// <param name="entityId"></param>
    /// <param name="relationPropertyName"></param>
    /// <returns></returns>
    public async Task<List<int>> RelationsIdsAsync(int entityId, string relationPropertyName)
    {
      var entity = await GetByIdAsync(entityId);
      if (entity == null)
      {
        return null;
      }
      var relationUrls = GetRelationsUrls(entity, relationPropertyName);
      if (relationUrls == null || !relationUrls.Any())
      {
        return new List<int>();
      }
      var relationIds = relationUrls.Select(url => entity.GetIdFromUrl(url)).ToList();
      return relationIds;
    }
    /// <summary>
    /// Gets the relations URLs.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="relationPropertyName"></param>
    /// <returns></returns>
    private List<string> GetRelationsUrls(T entity, string relationPropertyName)
    {
      return entity.GetType().GetProperty(relationPropertyName).GetValue(entity, null) as List<string>;
    }
  }
}