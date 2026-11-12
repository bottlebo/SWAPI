using SWAPI.SERVICES;
using SWAPI.DATA;
using SWAPI.JSON.JsonModels;
using SWAPI.MAPPER;
using SWAPI.DOMAIN.Models;
namespace SWAPI
{
  public static class ProgramExtensions
  {
    public static void AddServices(this WebApplicationBuilder builder)
    {
      builder.Services.AddScoped<FilmService>();
      builder.Services.AddScoped<PersonService>();
      builder.Services.AddScoped<IJsonRepository<FilmJson>, Repository<FilmJson>>();
      builder.Services.AddScoped<IJsonRepository<PersonJson>, Repository<PersonJson>>();

      builder.Services.AddScoped<IDataService, JsonFileDataService>();
    }
    public static void AddMappers(this WebApplicationBuilder builder)
    {
      builder.Services.AddSingleton<IMapper<FilmJson, Film>, FilmJsonToFilmMapper>();
      builder.Services.AddSingleton<IMapper<PersonJson, Person>, PersonJsonToPersonMapper>();
      builder.Services.AddSingleton(MapperService =>
      {
        var mapperService = new MapperService();
        var filmMapper = MapperService.GetRequiredService<IMapper<FilmJson, Film>>();
        var personMapper = MapperService.GetRequiredService<IMapper<PersonJson, Person>>();
        mapperService.RegisterMapper(filmMapper);
        mapperService.RegisterMapper(personMapper);
        return mapperService;
      });
    }
  }
}