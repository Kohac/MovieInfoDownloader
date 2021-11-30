using log4net.Config;
using MovieInformationDownloader.Services;


namespace MovieInformationDownloader;
class Program
{
    public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    private static readonly MovieRepository _movieRepository = new();
    private static readonly PersonRepository _personRepository = new();
    private static readonly PairModelAndEntity _pairModelAndEntity = new();
    static void Main(string[] args)
    {
        //ConfigureLogs();
        //for (int i = 15340; i < 17734; i++)
        //{
        //    long actualMovieId = i;
        //    Console.WriteLine($"Application starting with movie id: {actualMovieId}");
        //    MovieDto movieDto = DownloadAndReturnMovieInfo(ref actualMovieId);
        //    Movie movieEntity = _pairModelAndEntity.GetMovieEntityFromModel(movieDto);
        //    if (_movieRepository.CheckIfMovieIdExists(actualMovieId))
        //    {
        //        _movieRepository.UpdateMovie(movieEntity);
        //    }
        //    else
        //    {
        //        _movieRepository.InsertMovie(movieEntity);
        //    }
        //    _movieRepository.UpdateMovie(movieEntity);
        //}
        RunApp(args);
    }
    private static void RunApp(string[] args)
    {
        ConfigureLogs();
        log.Info("Application Start");
        if (args.Length <= 0)
        {
            Console.WriteLine("No arguments were passed. Application end.");
            log.Info("No arguments were passed. Application end.");
        }
        else
        {
            //Person Info downloader
            if (args[0] == "-person")
            {
                for (int p = 0; p < int.Parse(args[1]); p++)
                {
                    long personId = _personRepository.GetPersonId();
                    Console.WriteLine($"Application starting with person id: {personId}");
                    PersonDto personDto = DownloadAndReturnPersonInfo(personId);
                    Person person = _pairModelAndEntity.GetPersonEntityFromModel(personDto);
                    _personRepository.InsertPerson(person);
                }
            }

            //Movie Info downloader
            if (args[0] == "-movie")
            {
                for (int i = 0; i < int.Parse(args[1]); i++)
                {
                    long actualMovieId = _movieRepository.GetMovieId();
                    Console.WriteLine($"Application starting with movie id: {actualMovieId}");
                    MovieDto movieDto = DownloadAndReturnMovieInfo(ref actualMovieId);
                    Movie movieEntity = _pairModelAndEntity.GetMovieEntityFromModel(movieDto);
                    _movieRepository.InsertMovie(movieEntity);
                }
            }
            log.Info("Application End");
        }
    }
    private static void ConfigureLogs()
    {
        string directory = AppDomain.CurrentDomain.BaseDirectory;
        string fullPath = Path.Combine(directory, "log4net.config");
        XmlConfigurator.Configure(new FileInfo(fullPath));
    }
    private static MovieDto DownloadAndReturnMovieInfo(ref long movieId)
    {
        WebDownloader webDownloader = new WebDownloader();
        WebHandler webHandler = new WebHandler();
        try
        {
            Encoding encoding = CodePagesEncodingProvider.Instance.GetEncoding("Windows-1250");
            var jsonConfigurationFile = File.ReadAllText(AppContext.BaseDirectory + "/Services/Data/HtmlSearchMovieKeys.json", encoding);
            var keys = JsonConvert.DeserializeObject<JsonMapperMovie>(jsonConfigurationFile);
            string pageContent = webDownloader.DownloadPageContentMovieHtml(movieId);
            while (pageContent == null)
            {
                long originalMovieId = movieId;
                Console.WriteLine($"Movie with id: {movieId} doesn't exist i am trying to find +1.");
                log.Debug($"Movie with id: {movieId} doesn't exist i am trying to find +1.");
                movieId = movieId + 1;
                pageContent = webDownloader.DownloadPageContentMovieHtml(movieId);
                if (originalMovieId + 10 == movieId)
                {
                    pageContent = "Just secure from internal loop";
                    log.Info("No more movies to download available!");
                    Environment.Exit(0);
                }
            }
            MovieDto movieInfo = webHandler.GetMovieInfo(movieId, pageContent, keys);
            return movieInfo;
        }
        catch (Exception ex)
        {
            log.Error($"Error while doenloading movie information: {ex.Message} \n\t {ex.StackTrace} \n\t {ex.HResult}");
        }
        return null;
    }
    private static PersonDto DownloadAndReturnPersonInfo(long personId)
    {
        WebDownloader webDownloader = new WebDownloader();
        WebHandler webHandler = new WebHandler();
        try
        {
            Encoding encoding = CodePagesEncodingProvider.Instance.GetEncoding("Windows-1250");
            var jsonConfigurationFile = File.ReadAllText(AppContext.BaseDirectory + "/Services/data/HtmlSearchPersonKeys.json", encoding);
            var keys = JsonConvert.DeserializeObject<JsonMapperPerson>(jsonConfigurationFile);
            string pageContent = webDownloader.DownloadPageContentPersonHtml(personId);
            PersonDto personInfo = webHandler.GetPersonInfo(personId, pageContent, keys);
            return personInfo;
        }
        catch (Exception ex)
        {
            log.Error($"Error while doenloading movie information: {ex.Message} \n\t {ex.StackTrace} \n\t {ex.HResult}");
        }
        return null;
    }
}