namespace MovieInformationDownloader.services;
public class WebDownloader
{
    public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public string DownloadPageContentMovieHtml(long movieId)
    {
        using (var client = new HttpClient())
        {
            try
            {
                var response = client.GetStringAsync($"https://www.csfd.cz/film/{movieId}").Result;
                return response;
            }
            catch (Exception ex)
            {
                log.Error($"Error: {ex.Message} \n\t {ex.StackTrace} \n\t {ex.Source}");
                return null;
            }
        }
    }
    public string DownloadPageContentPersonHtml(long personId)
    {
        using (var client = new HttpClient())
        {
            try
            {
                var response = client.GetStringAsync($"https://www.csfd.cz/tvurce/{personId}/biografie").Result;
                return response;
            }
            catch (Exception ex)
            {
                log.Error($"Error: {ex.Message} \n\t {ex.StackTrace} \n\t {ex.Source}");
                return null;
            }
        }
    }
}