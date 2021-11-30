namespace MovieInformationDownloader.Services;
public class WebHandler
{
    public readonly HtmlHandler htmlHandler = new ();
    public MovieDto GetMovieInfo(long movieId, string pageContent, JsonMapperMovie htmlKeys)
    {
        MovieDto movie = new MovieDto();
        movie.MovieId = movieId;
        foreach (var key in htmlKeys.HtmlPairKeys)
        {
            switch (key.Name)
            {
                case HtmlKeysEnumerator.HtmlMovieKeys.Name:
                    movie.Name = htmlHandler.SubstringHtmlElementAndClearTextFormatters(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlMovieKeys.Rating:
                    movie.Rating = htmlHandler.SubstringHtmlElementAndClearTextFormatters(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlMovieKeys.Genres:
                    string genres = htmlHandler.SubstringHtmlElementAndClearTextFormatters(ref pageContent, key.StartValue, key.EndValue);
                    movie.Genres = genres.Split("/");
                    break;
                case HtmlKeysEnumerator.HtmlMovieKeys.Origin:
                    string origin = htmlHandler.SubstringHtmlElementClearTextFormattersAndClearHtmlStaff(ref pageContent, key.StartValue, key.EndValue);
                    string[] originSplit = origin.Split(",");
                    if (originSplit.Length == 1)
                    {
                        movie.CountryOfOrigin = originSplit[0];
                    }
                    else if (originSplit.Length == 2)
                    {
                        movie.CountryOfOrigin = originSplit[0];
                        movie.YearCreated = originSplit[1];
                    }
                    else if (originSplit.Length == 3)
                    {
                        movie.CountryOfOrigin = originSplit[0];
                        movie.YearCreated = originSplit[1];
                        movie.Duration = originSplit[2];
                    }
                    break;
                case HtmlKeysEnumerator.HtmlMovieKeys.Director:
                    movie.Director = htmlHandler.SubstringDirectorIds(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlMovieKeys.Template:
                    movie.Template = htmlHandler.SubstringDirectorIds(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlMovieKeys.Scenario:
                    movie.Scenario = htmlHandler.SubstringDirectorIds(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlMovieKeys.Camera:
                    movie.Camera = htmlHandler.SubstringDirectorIds(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlMovieKeys.Audio:
                    movie.Audio = htmlHandler.SubstringDirectorIds(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlMovieKeys.Actors:
                    movie.Actors = htmlHandler.SubstringDirectorIds(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlMovieKeys.Content:
                    movie.Content = htmlHandler.SubstringHtmlElementClearTextFormattersAndClearHtmlStaff(ref pageContent, key.StartValue, key.EndValue);
                    if (movie.Content is null)
                    {
                        movie.Content = htmlHandler.SubstringHtmlElementClearTextFormattersAndClearHtmlStaff(
                                                                                                                ref pageContent, 
                                                                                                                "<div class=\"plot-full\">", 
                                                                                                                "</div>");
                    }
                    break;
                case HtmlKeysEnumerator.HtmlMovieKeys.OtherFilmNames:
                    movie.OtherFilmNames = htmlHandler.SubstringOtherFilmNames(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlMovieKeys.CinemaPremiere:
                    movie.CinemaPremiere = htmlHandler.SubstringCinemaPremieres(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlMovieKeys.AgeWarning:
                    movie.AgeWarning = htmlHandler.SubstringHtmlElementClearTextFormattersAndClearHtmlStaff(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlMovieKeys.RelatedMovies:
                    movie.RelatedMoviesId = htmlHandler.SubstringRelatedMovies(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlMovieKeys.Tags:
                    string tags = htmlHandler.SubstringHtmlElementClearTextFormattersAndClearHtmlStaff(ref pageContent, key.StartValue, key.EndValue);
                    if (!string.IsNullOrEmpty(tags))
                    {
                        tags = tags.Replace("Tagy", "");
                        string[] tagSplit = tags.Split(",");
                        movie.Tags = tagSplit;
                    }
                    break;
            }
        }
        return movie;
    }
    public PersonDto GetPersonInfo(long personId, string pageContent, JsonMapperPerson htmlKeys)
    {
        PersonDto person = new();
        person.PersonId = personId;
        foreach (var key in htmlKeys.HtmlPairPersonKeys)
        {
            switch (key.Name)
            {
                case HtmlKeysEnumerator.HtmlPersonKeys.PersonalData:
                    var personalData = htmlHandler.GetPersonData(ref pageContent, key.StartValue, key.EndValue, person);
                    break;
                case HtmlKeysEnumerator.HtmlPersonKeys.Biography:
                    person.Biography = htmlHandler.GetPersonBiography(ref pageContent, key.StartValue, key.EndValue);
                    break;
            }
        }
        return person;
    }
}