namespace SWAPI.DATA
{
    /// <summary>
    /// A Service for consuming data from remote source. 
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// Gets the data result as JSON. The syntax and format of the result should be valid. 
        /// </summary>
        /// <param name="path">The path for consuming.</param>
        /// <returns>JSON data as string.</returns>
        Task<string> GetDataResultAsync(string path);
    }
}