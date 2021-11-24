namespace MovieInformationDownloader.Utilities.ModelAndEntity;
internal class PairModelAndEntity
{
    public Movie GetMovieEntityFromModel(MovieDto modelMovie)
    {
        Movie movieEntity = new();
        List<Genre> genres = new();
        List<Director> directors = new();
        List<Template> templates = new();
        List<Scenario> scenarios = new();
        List<Camera> cameras = new();
        List<Audio> audios = new();
        List<Actor> actors = new();
        List<OtherMovieName> otherMovieNames = new();
        List<CinemaPremiere> cinemaPremieres = new();
        List<RelatedMovie> relatedMovies = new();
        //Movie entity filling
        movieEntity.MovieId = modelMovie.MovieId;
        movieEntity.Name = modelMovie.Name;
        movieEntity.Rating = modelMovie.Rating;
        movieEntity.CountryOfOrigin = modelMovie.CountryOfOrigin;
        movieEntity.CreatedYear = modelMovie.YearCreated;
        movieEntity.Duration = modelMovie.Duration;
        movieEntity.MovieContent = modelMovie.Content;
        movieEntity.AgeWarning = modelMovie.AgeWarning;
        //Genre entity filling
        if (modelMovie.Genres != null)
        {
            foreach (var genre in modelMovie.Genres)
            {
                genres.Add(new Genre() { Genre1 = genre, Movie = movieEntity });
            }
            movieEntity.Genres = genres;
        }
        //Director entity filling
        if (modelMovie.Director != null)
        {
            foreach (var director in modelMovie.Director)
            {
                directors.Add(new Director() { PersonId = long.Parse(director), Movie = movieEntity });
            }
            movieEntity.Directors = directors;
        }
        //Template entity filling
        if (modelMovie.Template != null)
        {
            foreach (var template in modelMovie.Template)
            {
                templates.Add(new Template() { PersonId = long.Parse(template), Movie = movieEntity });
            }
            movieEntity.Templates = templates;
        }
        //Scenarios entity filling
        if (modelMovie.Scenario != null)
        {
            foreach (var scenario in modelMovie.Scenario)
            {
                scenarios.Add(new Scenario() { PersonId = long.Parse(scenario), Movie = movieEntity });
            }
            movieEntity.Scenarios = scenarios;
        }
        //Camera entity filling
        if (modelMovie.Camera != null)
        {
            foreach (var camera in modelMovie.Camera)
            {
                cameras.Add(new Camera() { PersonId = long.Parse(camera), Movie = movieEntity });
            }
            movieEntity.Cameras = cameras;
        }
        //Audio entity filling
        if (modelMovie.Audio != null)
        {
            foreach (var audio in modelMovie.Audio)
            {
                audios.Add(new Audio() { PersonId = long.Parse(audio), Movie = movieEntity });
            }
            movieEntity.Audios = audios;
        }
        //Actors entity filling
        if (modelMovie.Actors != null)
        {
            foreach (var actor in modelMovie.Actors)
            {
                actors.Add(new Actor() { PersonId = long.Parse(actor), Movie = movieEntity });
            }
            movieEntity.Actors = actors;
        }
        //OtherMovieName entity filling
        if (modelMovie.OtherFilmNames != null)
        {
            foreach (var otherMovieName in modelMovie.OtherFilmNames)
            {
                otherMovieNames.Add(
                    new OtherMovieName() {
                        Country = otherMovieName.Country,
                        Name = otherMovieName.Name,
                        Movie = movieEntity
                    });
            }
            movieEntity.OtherMovieNames = otherMovieNames;
        }
        //CinemaPremiere entity filling
        if (modelMovie.CinemaPremiere != null)
        {
            foreach (var cinemaPremiere in modelMovie.CinemaPremiere)
            {
                cinemaPremieres.Add(
                    new CinemaPremiere() {
                        Country = cinemaPremiere.Country,
                        InCinemaFrom = cinemaPremiere.InCinemaFrom,
                        Movie = movieEntity
                    });
            }
            movieEntity.CinemaPremieres = cinemaPremieres;
        }
        //RelatedMovie entity mapping
        if (modelMovie.RelatedMoviesId != null)
        {
            foreach (var relatedMovie in modelMovie.RelatedMoviesId)
            {
                relatedMovies.Add(new RelatedMovie() { RelatedMovieId = relatedMovie ?? 0, Movie = movieEntity });
            }
            movieEntity.RelatedMovies = relatedMovies;
        }
        return movieEntity;
    }
    public Person GetPersonEntityFromModel(PersonDto personDto)
    {
        Person person = new() {
            PersonId = personDto.PersonId,
            Forename = personDto.Forename ?? null,
            Surname = personDto.Surname ?? null,
            DateOfBirth = personDto.DateOfBirth ?? null,
            City = personDto.City ?? null,
            Country = personDto.Country ?? null,
            Continent = personDto.Continent ?? null,
            Biography = personDto.Biography ?? null
        };
        return person;
    }
}