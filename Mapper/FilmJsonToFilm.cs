using SWAPI.DOMAIN.Models;
using SWAPI.JSON.JsonModels;
namespace SWAPI.MAPPER
{
  public class FilmJsonToFilmMapper : IMapper<FilmJson, Film>
  {
    public Film Map(FilmJson source)
    {
      return new Film
      {
        Id = source.GetIdFromUrl(),
        Title = source.Title,
        EpisodeId = int.Parse(source.EpisodeId),
        OpeningCrawl = source.OpeningCrawl,
        Director = source.Director,
        Producer = source.Producer,
        ReleaseDate = DateTime.Parse(source.ReleaseDate),
      };
    }
  }
}