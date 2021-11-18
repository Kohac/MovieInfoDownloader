namespace MovieInformationDownloader.services;
public class WebDownloader
{
    public string DownloadPageContentHtml(long movieId)
    {
        using (var client = new HttpClient())
        {
            var response = client.GetStringAsync($"https://www.csfd.cz/film/{movieId}").Result;
            return response;
        }
    }
}