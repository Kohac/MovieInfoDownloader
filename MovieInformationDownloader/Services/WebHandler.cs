namespace MovieInformationDownloader.services;
public class WebHandler
{
    public MovieDto GetMovieInfo(long movieId, string pageContent, JsonMapper htmlKeys)
    {
        MovieDto movie = new MovieDto();
        HtmlHandler htmlHandler = new HtmlHandler();
        movie.MovieId = movieId;
        foreach (var key in htmlKeys.HtmlPairKeys)
        {
            switch (key.Name)
            {
                case HtmlKeysEnumerator.HtmlKeys.Name:
                    movie.Name = htmlHandler.SubstringHtmlElementAndClearTextFormatters(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlKeys.Rating:
                    movie.Rating = htmlHandler.SubstringHtmlElementAndClearTextFormatters(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlKeys.Genres:
                    string genres = htmlHandler.SubstringHtmlElementAndClearTextFormatters(ref pageContent, key.StartValue, key.EndValue);
                    movie.Genres = genres.Split("/");
                    break;
                case HtmlKeysEnumerator.HtmlKeys.Origin:
                    string origin = htmlHandler.SubstringHtmlElementClearTextFormattersAndClearHtmlStaff(ref pageContent, key.StartValue, key.EndValue);
                    string[] originSplit = origin.Split(",");
                    movie.CountryOfOrigin = originSplit[0];
                    movie.YearCreated = originSplit[1];
                    movie.Duration = originSplit[2];
                    break;
                case HtmlKeysEnumerator.HtmlKeys.Director:
                    movie.Director = htmlHandler.SubstringDirectorIds(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlKeys.Template:
                    movie.Template = htmlHandler.SubstringDirectorIds(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlKeys.Scenario:
                    movie.Scenario = htmlHandler.SubstringDirectorIds(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlKeys.Camera:
                    movie.Camera = htmlHandler.SubstringDirectorIds(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlKeys.Audio:
                    movie.Audio = htmlHandler.SubstringDirectorIds(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlKeys.Actors:
                    movie.Actors = htmlHandler.SubstringDirectorIds(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlKeys.Content:
                    movie.Content = htmlHandler.SubstringHtmlElementClearTextFormattersAndClearHtmlStaff(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlKeys.OtherFilmNames:
                    movie.OtherFilmNames = htmlHandler.SubstringOtherFilmNames(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlKeys.CinemaPremiere:
                    movie.CinemaPremiere = htmlHandler.SubstringCinemaPremieres(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlKeys.AgeWarning:
                    movie.AgeWarning = htmlHandler.SubstringHtmlElementClearTextFormattersAndClearHtmlStaff(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlKeys.RelatedMovies:
                    movie.RelatedMoviesId = htmlHandler.SubstringRelatedMovies(ref pageContent, key.StartValue, key.EndValue);
                    break;
                case HtmlKeysEnumerator.HtmlKeys.Tags:
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
}