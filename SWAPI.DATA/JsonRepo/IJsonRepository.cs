 using System.Collections.Generic;
 using SWAPI.JSON.JsonModels;
namespace SWAPI.DATA
{
    /// <summary>
    /// Interface IJsonRepository
    /// </summary>
    public interface IJsonRepository<T> where T : BaseJsonModel
    {
        /// <summary>
        /// Gets the entity by it's identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Gets entities.
        /// </summary>
        Task<ICollection<T>> GetEntitiesAsync();
        Task<T> GetEntityByUrlAsync(string url);
        Task<ICollection<T>> GetEntitiesByUrlsAsync(List<string> urls);
        Task<ICollection<T>> GetEntitiesByIdsAsync(List<int> ids);
        Task<List<int>> RelationsIdsAsync(int entityId, string relationPropertyName);
    }
}