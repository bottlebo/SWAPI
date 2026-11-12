
using System;
using Newtonsoft.Json;
namespace SWAPI.JSON.JsonModels
{
  /// <summary>
  /// Base entity class contains common data.
  /// </summary>
  public abstract class BaseJsonModel
  {
    private const string BaseUrl = "https://swapi.dev/api/";
    /// <summary>
    /// Gets or sets the URL from where was downloaded the entity.
    /// </summary>
    [JsonProperty]
    public string Url { get; set; }

    /// <summary>
    /// Gets or sets the date of creation of the entity.
    /// </summary>
    [JsonProperty]
    public DateTime Created { get; set; }

    /// <summary>
    /// Gets or sets the date of last modification.
    /// </summary>
    [JsonProperty]
    public DateTime Edited { get; set; }

    /// <summary>
    /// Gets the path.
    /// </summary>
    protected abstract string EntryPath { get; }

    /// <summary>
    /// Gets the path for extending base URL API.
    /// </summary>
    /// <returns>System.String the path.</returns>
    public string GetPath()
    {
      return this.EntryPath;
    }
    /// <summary>
    /// Gets the identifier from URL.
    /// </summary>
    /// <returns>System.Int32 the identifier.</returns>
    public int GetIdFromUrl()
    {
      return GetIdFromUrl(this.Url);
    }
    /// <summary>
    /// Gets the identifier from URL.
    /// </summary>
    /// <param name="url"></param>
    /// <returns>System.Int32 the identifier.</returns>
    public int GetIdFromUrl(string url)
    {
      if (string.IsNullOrEmpty(url))
      {
        return -1;
      }
      var segments = url.Split('/');
      if (segments.Length < 2)
      {
        return -1;
      }
      if (!int.TryParse(segments[^2], out int id))
      {
        return -1;
      }
      return id;
    }
  }
}