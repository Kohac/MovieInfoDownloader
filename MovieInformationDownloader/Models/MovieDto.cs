namespace MovieInformationDownloader.Models;
public class MovieDto
{
    public long MovieId { get; set; }
    public string Name { get; set; }
    public string Rating { get; set; }
    public string[] Genres { get; set; }
    public string CountryOfOrigin { get; set; }
    public string YearCreated { get; set; }
    public string Duration { get; set; }
    public string Content { get; set; }
    public string AgeWarning { get; set; }
    public List<string> Director { get; set; }
    public List<string> Template { get; set; }
    public List<string> Scenario { get; set; }
    public List<string> Camera { get; set; }
    public List<string> Audio { get; set; }
    public List<string> Actors { get; set; }
    public ICollection<OtherFilmNamesDto> OtherFilmNames { get; set; } = new List<OtherFilmNamesDto>();
    public ICollection<CinemaPremieresDto> CinemaPremiere { get; set; } = new List<CinemaPremieresDto>();
    public ICollection<long?> RelatedMoviesId { get; set; }
    public string[] Tags { get; set; }
}