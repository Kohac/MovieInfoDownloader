namespace MovieInformationDownloader.Models;

public class PersonDto
{
    public long PersonId { get; set; }
    public string Forename { get; set; }
    public string Surname { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Continent { get; set; }
    public string Biography { get; set; }

}
