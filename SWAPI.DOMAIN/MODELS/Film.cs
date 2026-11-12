namespace SWAPI.DOMAIN.Models
{
    public class Film: BaseModel
    {
        public string Title { get; set; }
        public int EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<Person> Characters { get; set; }
        // public ICollection<string> Planets { get; set; }
        // public ICollection<string> Starships { get; set; }
        // public ICollection<string> Vehicles { get; set; }
    }
}