namespace MovieInformationDownloader.Utilities;
public class HtmlHandler
{
    public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public string SubstringHtmlElementAndClearTextFormatters(ref string pageContent, string startValue, string endValue)
    {
        if (!pageContent.Contains(startValue))
        {
            return null;
        }
        int startSearchCount = pageContent.IndexOf(startValue);
        int endSearchCount = pageContent.IndexOf(endValue, startSearchCount);
        int substringFrom = startSearchCount + startValue.Length;
        int substringTo = endSearchCount - substringFrom;
        string result = pageContent.Substring(substringFrom, substringTo).ReplaceTabCharacters().ReplaceNewLineCharacters();
        pageContent = pageContent.Remove(substringFrom, substringTo);
        return result;
    }
    public string SubstringHtmlElementClearTextFormattersAndClearHtmlStaff(ref string pageContent, string startValue, string endValue)
    {
        if (!pageContent.Contains(startValue))
        {
            return null;
        }
        int startSearchCount = pageContent.IndexOf(startValue);
        int endSearchCount = pageContent.IndexOf(endValue, startSearchCount);
        int substringFrom = startSearchCount + startValue.Length;
        int substringTo = endSearchCount - substringFrom;
        string result = pageContent.Substring(substringFrom, substringTo).ReplaceTabCharacters().ReplaceNewLineCharacters().ReplaceAllHTMLStaff();
        pageContent = pageContent.Remove(substringFrom, substringTo);
        return result;
    }
    public List<OtherFilmNamesDto> SubstringOtherFilmNames(ref string pageContent, string startValue, string endValue)
    {
        if (!pageContent.Contains(startValue))
        {
            return null;
        }
        List<OtherFilmNamesDto> otherFilmNames = new List<OtherFilmNamesDto>();
        int startSearchCount = pageContent.IndexOf(startValue);
        int endSearchCount = pageContent.IndexOf(endValue, startSearchCount);
        int substringFrom = startSearchCount + startValue.Length;
        int substringTo = endSearchCount - substringFrom;
        string result = pageContent.Substring(substringFrom, substringTo).ReplaceTabCharacters().ReplaceNewLineCharacters();

        while (result.Contains("<li"))
        {
            int startSearchCountLi = result.IndexOf("<li");
            int endSearchCountLi = result.IndexOf("</li>", startSearchCountLi);
            int substringFromLi = startSearchCountLi /*+ "<li".Length*/;
            int substringToLi = endSearchCountLi - substringFromLi;
            string resultLi = result.Substring(substringFromLi, substringToLi + "</li>".Length); 

            int startSearchCountLiCountry = result.IndexOf("title=\"");
            int endSearchCountLiCountry = result.IndexOf("\"", startSearchCountLiCountry + "title=\"".Length);
            int substringFromLiCountry = startSearchCountLiCountry + "title=\"".Length;
            int substringToLiCountry = endSearchCountLiCountry - substringFromLiCountry;
            string resultLiCountry = result.Substring(substringFromLiCountry, substringToLiCountry);

            otherFilmNames.Add(new OtherFilmNamesDto() { Country = resultLiCountry, Name = resultLi.ReplaceAllHTMLStaff().RemoveButtonNames()});

            result = result.Remove(substringFromLi, substringToLi + "</li>".Length);
        }
        pageContent = pageContent.Remove(substringFrom, substringTo);
        return otherFilmNames;
    }

    internal List<string> SubstringDirectorIds(ref string pageContent, string startValue, string endValue)
    {
        if (!pageContent.Contains(startValue))
        {
            return null;
        }
        List<string> directorIds = new List<string>();
        int startSearchCount = pageContent.IndexOf(startValue);
        int endSearchCount = pageContent.IndexOf(endValue, startSearchCount);
        int substringFrom = startSearchCount + startValue.Length;
        int substringTo = endSearchCount - substringFrom;
        string result = pageContent.Substring(substringFrom, substringTo).ReplaceTabCharacters().ReplaceNewLineCharacters();

        while (result.Contains("<a href=\"/tvurce/"))
        {
            int startSearchCountA = result.IndexOf("<a href=\"/tvurce/");
            int endSearchCountA = result.IndexOf("-", startSearchCountA);
            int substringFromA = startSearchCountA + "<a href=\"/tvurce/".Length;
            int substringToA = endSearchCountA - substringFromA - 1;
            string resultA = result.Substring(substringFromA, substringToA + "-".Length);

            directorIds.Add(resultA);

            result = result.Remove(startSearchCountA, substringToA + "-".Length);
        }
        pageContent = pageContent.Remove(substringFrom, substringTo);
        return directorIds;
    }

    public ICollection<CinemaPremieresDto> SubstringCinemaPremieres(ref string pageContent, string startValue, string endValue)
    {
        if (!pageContent.Contains(startValue))
        {
            return null;
        }
        //find section for cinema premieres
        ICollection<CinemaPremieresDto> cinemaPremieres = new List<CinemaPremieresDto>();
        int startSearchCount = pageContent.IndexOf(startValue);
        int endSearchCount = pageContent.IndexOf(endValue, startSearchCount);
        int substringFrom = startSearchCount + startValue.Length;
        int substringTo = endSearchCount - substringFrom;
        string result = pageContent.Substring(substringFrom, substringTo).ReplaceTabCharacters().ReplaceNewLineCharacters();
        //find unordered list of cinema premieres
        if (!result.Contains("<ul>"))
        {
            return null;
        }
        int startSearchCountUl = result.IndexOf("<ul>");
        int endSearchCountUl = result.IndexOf("</ul>", startSearchCountUl);
        int substringFromUl = startSearchCountUl + "<ul>".Length;
        int substringToUl = endSearchCountUl - substringFromUl;
        string resultUl = result.Substring(substringFromUl, substringToUl);


        while (resultUl.Contains("<li"))
        {
            int startSearchCountLi = resultUl.IndexOf("<li");
            int endSearchCountLi = resultUl.IndexOf("</li>", startSearchCountLi);
            int substringFromLi = startSearchCountLi /*+ "<li".Length*/;
            int substringToLi = endSearchCountLi - substringFromLi;
            string resultLi = resultUl.Substring(substringFromLi, substringToLi + "</li>".Length);

            int startSearchCountLiCountry = resultUl.IndexOf("title=\"");
            int endSearchCountLiCountry = resultUl.IndexOf("\"", startSearchCountLiCountry + "title=\"".Length);
            int substringFromLiCountry = startSearchCountLiCountry + "title=\"".Length;
            int substringToLiCountry = endSearchCountLiCountry - substringFromLiCountry;
            string resultLiCountry = resultUl.Substring(substringFromLiCountry, substringToLiCountry);
            string inCinemaFrom = resultLi.ReplaceAllHTMLStaff();
            int splitWordCount = inCinemaFrom.IndexOf("od") + "od".Length;
            cinemaPremieres.Add(new CinemaPremieresDto() {Country = resultLiCountry, InCinemaFrom = inCinemaFrom.Insert(splitWordCount," ")});

            resultUl = resultUl.Remove(substringFromLi, substringToLi + "</li>".Length);
        }
        pageContent = pageContent.Remove(substringFrom, substringTo);
        return cinemaPremieres;
    }

    internal ICollection<long?> SubstringRelatedMovies(ref string pageContent, string startValue, string endValue)
    {
        if (!pageContent.Contains(startValue))
        {
            return null;
        }
        List<long?> relatedMovies = new List<long?>();
        int startSearchCount = pageContent.IndexOf(startValue);
        int endSearchCount = pageContent.IndexOf(endValue, startSearchCount);
        int substringFrom = startSearchCount + startValue.Length;
        int substringTo = endSearchCount - substringFrom;
        string result = pageContent.Substring(substringFrom, substringTo).ReplaceTabCharacters().ReplaceNewLineCharacters();

        while (result.Contains("<h3 c"))
        {
            int startSearchCountHeading = result.IndexOf("<h3 c");
            int endSearchCountHeading = result.IndexOf("</h3>", startSearchCountHeading);
            int substringFromHeading = startSearchCountHeading /*+ "<h3".Length*/;
            int substringToHeading = endSearchCountHeading - substringFromHeading;
            string resultHeading = result.Substring(substringFromHeading, substringToHeading + "</h3>".Length);

            int startSearchCountMovie = resultHeading.IndexOf("href=\"/film/");
            int endSearchCountMovie = resultHeading.IndexOf("-", startSearchCountMovie + "href=\"/film/".Length);
            int substringFromMovie = startSearchCountMovie + "href=\"/film/".Length;
            int substringToMovie = endSearchCountMovie - substringFromMovie;
            string resultMovie = resultHeading.Substring(substringFromMovie, substringToMovie);

            long resultMovieId;
            long.TryParse(resultMovie, out resultMovieId);

            relatedMovies.Add(resultMovieId);

            result = result.Remove(substringFromHeading, substringToHeading + "</h3>".Length);
        }
        pageContent = pageContent.Remove(substringFrom - startValue.Length, substringTo + endValue.Length);
        return relatedMovies;
    }
    public PersonDto GetPersonData(ref string pageContent, string startValue, string endValue, PersonDto person)
    {
        try
        {
            if (!pageContent.Contains(startValue))
            {
                startValue = "<div class=\"creator-profile-content creator-profile-content-nocopyright\">";
                if (!pageContent.Contains(startValue))
                {
                    return null;
                }
            }
            int startSearchCount = pageContent.IndexOf(startValue);
            int endSearchCount = pageContent.IndexOf(endValue, startSearchCount);
            int substringFrom = startSearchCount + startValue.Length;
            int substringTo = endSearchCount - substringFrom + endValue.Length;
            string result = pageContent.Substring(substringFrom, substringTo);

            int startSearchName = result.IndexOf("<h1>");
            int endSearchName = result.IndexOf("</h1>", startSearchName);
            int substringFromName = startSearchName + "<h1>".Length;
            int substringToName = endSearchName - substringFromName;
            string name = result.Substring(substringFromName, substringToName);
            string[] nameSplitted = name.Split(" ");
            person.Forename = nameSplitted[0].ReplaceNewLineCharacters().ReplaceTabCharacters();
            person.Surname = nameSplitted[1].ReplaceNewLineCharacters().ReplaceTabCharacters();

            int startSearchDateOfBirth = result.IndexOf("<p>");
            int endSearchNameDateOfBirth = result.IndexOf("(", startSearchDateOfBirth) == -1 
                ? result.IndexOf("<br>", startSearchDateOfBirth) 
                : result.IndexOf("(", startSearchDateOfBirth);
            //secure if person died
            //if (startSearchDateOfBirth + 100 >= endSearchNameDateOfBirth)
            //{
            //    endSearchNameDateOfBirth = result.IndexOf("<br>", startSearchDateOfBirth);
            //}
            int substringFromDateOfBirth = startSearchDateOfBirth + "<p>".Length;
            int substringToDateOfBirth = endSearchNameDateOfBirth - substringFromDateOfBirth;
            if (endSearchNameDateOfBirth != -1)
            {
                string dateOfBirthString = result.Substring(substringFromDateOfBirth, substringToDateOfBirth).ReplaceNewLineCharacters().ReplaceTabCharacters().Replace("nar. ", "").Replace("zem. ", "").ReplaceAllHTMLStaff();
                DateTime dateOfBirth = new();
                DateTime.TryParse(dateOfBirthString, out dateOfBirth);
                person.DateOfBirth = dateOfBirth;
            }

            int startSearchAddressData = result.IndexOf("<br>");
            int endSearchNameAddressData = result.IndexOf("</p>", startSearchAddressData);
            int substringFromAddressData = startSearchAddressData + "<br>".Length;
            int substringToAddressData = endSearchNameAddressData - substringFromAddressData;
            if (endSearchNameAddressData != -1)
            {
                string addressData = result.Substring(substringFromAddressData, substringToAddressData).ReplaceNewLineCharacters().ReplaceTabCharacters();
                string[] addressDataSplitted = addressData.Split(",");

                if (addressDataSplitted.Length == 2)
                {
                    person.City = addressDataSplitted[0].ReplaceStarterSpace() ?? null;
                    person.Country = addressDataSplitted[1].ReplaceStarterSpace() ?? null;
                }
                else
                {
                    person.City = addressDataSplitted[0].ReplaceStarterSpace() ?? null;
                    person.Country = addressDataSplitted[1].ReplaceStarterSpace() ?? null;
                    person.Continent = addressDataSplitted[2].ReplaceStarterSpace() ?? null;
                }
            }
            return person;
        }
        catch (Exception ex)
        {
            log.Error($"Error: {ex.Message} \n\t {ex.StackTrace} \n\t {ex.Source}");
            return person;
        }

    }

    public string GetPersonBiography(ref string pageContent, string startValue, string endValue)
    {
        try
        {
            if (!pageContent.Contains(startValue))
            {
                return null;
            }
            int startSearchCount = pageContent.IndexOf(startValue);
            int endSearchCount = pageContent.IndexOf(endValue, startSearchCount);
            int substringFrom = startSearchCount + startValue.Length;
            int substringTo = endSearchCount - substringFrom;
            string result = pageContent.Substring(substringFrom, substringTo).ReplaceTabCharacters().ReplaceNewLineCharacters().ReplaceAllHTMLStaff();
            return result;
        }
        catch (Exception ex)
        {
            log.Error($"Error: {ex.Message} \n\t {ex.StackTrace} \n\t {ex.Source}");
            return null;
        }
        
        //int startSearchBiography = result.IndexOf("<p>");
        //int endSearchBiography = result.IndexOf("</p>", startSearchBiography);
        //int substringFromBiography = startSearchBiography + "<p>".Length;
        //int substringToBiography = endSearchBiography - substringFromBiography;
        //string biography = result.Substring(substringFromBiography, substringToBiography).ReplaceTabCharacters().ReplaceNewLineCharacters().ReplaceAllHTMLStaff();

    }
}