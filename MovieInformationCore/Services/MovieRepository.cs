using log4net;
using MovieInformationDownloader.Context;
using MovieInformationDownloader.Entities;

namespace MovieInformationDownloader.Services;

public class MovieRepository : AbstractMovie
{
    private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    private readonly MovieInfoContext _context = new();
    public bool CheckIfMovieIdExists(long movieId)
    {
        try
        {
            var result = _context.Movies.Find(movieId);
            if (result != null)
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            log.Error($"Error: {ex.Message} \n\t {ex.StackTrace} \n\t {ex.Source}");
            return false;
        }
        return false;
    }
    public override long GetMovieId()
    {
        try
        {
            var result = _context.Movies.Max(x => x.MovieId) + 1;
            return result;
        }
        catch (Exception ex)
        {
            log.Error($"Error: {ex.Message} \n\t {ex.StackTrace} \n\t {ex.Source}");
            return 1;
        }
    }

    public override void InsertMovie(Movie movie)
    {
        try
        {
            _context.Movies.Add(movie);
            Save();
            Console.WriteLine($"Movie with id: {movie.MovieId} was inserted to DB!");
        }
        catch (Exception ex)
        {
            log.Error($"Error: {ex.Message} \n\t {ex.StackTrace} \n\t {ex.Source}");
            Console.WriteLine($"Something wrong happen movie with id: {movie.MovieId} \n\t inner exception {ex.InnerException} cannot be save to DB!");
        }
    }

    public override bool Save()
    {
        return _context.SaveChanges() == 1 ? true : false;
    }

    public override void UpdateMovie(Movie movie)
    {
        try
        {
            _context.Movies.Update(movie);
            Save();
        }
        catch (Exception ex)
        {
            log.Error($"Error: {ex.Message} \n\t {ex.StackTrace} \n\t {ex.Source}");
        }
    }
}
