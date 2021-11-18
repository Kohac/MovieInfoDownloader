using MovieInformationDownloader.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInformationDownloader.DataMapper
{
    public class Mapper
    {
        public Mapper()
        {
            ListOfKeys = GetListOfKeys();
        }
        public IDictionary<string, HtmlSearchDto> ListOfKeys { get; set; }
        public IDictionary<string, HtmlSearchDto> GetListOfKeys()
        {
            var mappingDictionary = new Dictionary<string, HtmlSearchDto>();
            mappingDictionary.Add("Name", new HtmlSearchDto() { StartValue = "<h1 itemprop=\"name\">", EndValue = "</h1>" });
            mappingDictionary.Add("Rating", new HtmlSearchDto() { StartValue = "<div class=\"rating-average\">", EndValue = "</div>" });
            mappingDictionary.Add("Genres", new HtmlSearchDto() { StartValue = "<div class=\"genres\">", EndValue = "</div>" });
            mappingDictionary.Add("OriginalCountry", new HtmlSearchDto() { StartValue = "<div class=\"origin\">", EndValue = "," });
            mappingDictionary.Add("YearCreated", new HtmlSearchDto() { StartValue = "<span itemprop=\"dateCreated\">", EndValue = "</span>" });
            mappingDictionary.Add("Duration", new HtmlSearchDto() { StartValue = "<div class=\"origin\">", EndValue = "</div>" });
            mappingDictionary.Add("Director", new HtmlSearchDto() { StartValue = "<span itemprop=\"director\">", EndValue = "</span>" });
            mappingDictionary.Add("Template", new HtmlSearchDto() { StartValue = "<h4>Předloha: </h4>", EndValue = "</span>" });
            mappingDictionary.Add("Scenario", new HtmlSearchDto() { StartValue = "<h4>Scénář: </h4>", EndValue = "</span>" });
            mappingDictionary.Add("Camera", new HtmlSearchDto() { StartValue = "<h4>Kamera: </h4>", EndValue = "</span>" });
            mappingDictionary.Add("Audio", new HtmlSearchDto() { StartValue = "<h4>Hudba: </h4>", EndValue = "</span>" });
            mappingDictionary.Add("Actors", new HtmlSearchDto() { StartValue = "<h4>Hrají: </h4>", EndValue = "</span>" });
            mappingDictionary.Add("Content", new HtmlSearchDto() { StartValue = "<div class=\"plot-full hidden\">", EndValue = "</div>" });
            return mappingDictionary;
        }
    }
}
