using MovieInformationDownloader.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInformationDownloader.Services;

public abstract class AbstractMovie
{
    public abstract long GetMovieId();
    public abstract void InsertMovie(Movie movie);
    public abstract void UpdateMovie(Movie movie);
    public abstract bool Save();

}
