namespace MovieInformationDownloader.services;
public class WebDownloader
{
    public string DownloadPageContentMovieHtml(long movieId)
    {
        using (var client = new HttpClient())
        {
            var response = client.GetStringAsync($"https://www.csfd.cz/film/{movieId}").Result;
            return response;
        }
    }
    public string DownloadPageContentPersonHtml(long personId)
    {
        using (var client = new HttpClient())
        {
            var response = client.GetStringAsync($"https://www.csfd.cz/tvurce/{personId}/biografie").Result;
            return response;
        }
    }
}