namespace SWAPI.DOMAIN.Models
{
    public class Person: BaseModel
    {
        public string Name { get; set; }
        public string BirthYear { get; set; }
        public string EyeColor { get; set; }
        public string Gender { get; set; }
        public string HairColor { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public string SkinColor { get; set; }
        public string Homeworld { get; set; }
        public ICollection<Film> Films { get; set; }
        // public ICollection<string> Species { get; set; }
        // public ICollection<string> Starships { get; set; }
        // public ICollection<string> Vehicles { get; set; }
    }
}