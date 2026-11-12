using System.Reflection;
using System.Text;

namespace SWAPI.DATA
{
  public class JsonFileDataService : IDataService
  {
    private readonly ILogger<JsonFileDataService> _logger;

    public JsonFileDataService(ILogger<JsonFileDataService> logger)
    {
      _logger = logger;

    }
    /// <summary>
    /// Gets the data result asynchronous.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public async Task<string> GetDataResultAsync(string path)
    {
      var info = Assembly.GetExecutingAssembly().GetName();
      var name = info.Name;
      using var stream = Assembly
          .GetExecutingAssembly()
          .GetManifestResourceStream($"{name}.{name}.JSON.JsonData.{path}.json");
      using var streamReader = new StreamReader(stream, Encoding.UTF8);
      return await streamReader.ReadToEndAsync();
    }
  }
}