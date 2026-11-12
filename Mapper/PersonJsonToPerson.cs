using SWAPI.DOMAIN.Models;
using SWAPI.JSON.JsonModels;
namespace SWAPI.MAPPER
{
  public class PersonJsonToPersonMapper : IMapper<PersonJson, Person>
  {
    public Person Map(PersonJson source)
    {
      return new Person
      {
        Id = source.GetIdFromUrl(),
        Name = source.Name,
        BirthYear = source.BirthYear,
        EyeColor = source.EyeColor,
        Gender = source.Gender,
        HairColor = source.HairColor,
        Height = source.Height,
        Mass = source.Mass,
        SkinColor = source.SkinColor,
        Homeworld = source.Homeworld,
      };
    }
  }
}