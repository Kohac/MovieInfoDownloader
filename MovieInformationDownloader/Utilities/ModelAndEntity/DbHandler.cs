using MovieInformationDownloader.Context;

namespace MovieInformationDownloader.Utilities.ModelAndEntity;

internal class DbHandler
{
    private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public long GetMovieIdToDownload()
    {
        using (var context = new MovieInfoContext())
        {
            try
            {
                var result = context.Movies.Max(x => x.Id) + 1;
                return result;
            }
            catch (Exception ex)
            {
                log.Error($"Error: {ex.Message} \n\t {ex.StackTrace} \n\t {ex.Source}");
                return 1;
            }
        }
    }
    public void InsertMovieToDb(Movie movie)
    {
        using (var context = new MovieInfoContext())
        {
            try
            {
                context.Movies.Add(movie);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                log.Error($"Error: {ex.Message} \n\t {ex.StackTrace} \n\t {ex.Source}");
            }
        }
    }
}
