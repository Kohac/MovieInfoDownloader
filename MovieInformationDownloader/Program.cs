using MovieInformationDownloader.Services;

namespace MovieInformationDownloader;
class Program
{
    public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    //private static readonly DbHandler _dbHandler = new();
    private static readonly MovieRepository _movieRepository = new();
    private static readonly PairModelAndEntity pairModelAndEntity = new();
    static void Main(string[] args)
    {
        //for (int i = 0; i < 20; i++)
        //{
            ConfigureLogs();
            log.Info("Application Start");
            long actualMovieId = _movieRepository.GetMovieId();
            MovieDto movieDto = DownloadAndReturnMovieInfo(actualMovieId);
            Movie movieEntity = pairModelAndEntity.GetMovieEntityFromModel(movieDto);
            _movieRepository.InsertMovie(movieEntity);
            log.Info("Application End");
        //}
    }
    private static void ConfigureLogs()
    {
        string directory = AppDomain.CurrentDomain.BaseDirectory;
        string fullPath = Path.Combine(directory, "log4net.config");
        XmlConfigurator.Configure(new FileInfo(fullPath));
    }
    private static MovieDto DownloadAndReturnMovieInfo(long movieId)
    {
        WebDownloader webDownloader = new WebDownloader();
        WebHandler webHandler = new WebHandler();
        try
        {
            Encoding encoding = CodePagesEncodingProvider.Instance.GetEncoding("Windows-1250");
            var jsonConfigurationFile = File.ReadAllText(AppContext.BaseDirectory + "/Services/HtmlSearchKeys.json", encoding);
            var keys = JsonConvert.DeserializeObject<JsonMapper>(jsonConfigurationFile);
            string pageContent = webDownloader.DownloadPageContentHtml(movieId);
            MovieDto movieInfo = webHandler.GetMovieInfo(movieId, pageContent, keys);
            return movieInfo;
        }
        catch (Exception ex)
        {
            log.Error($"Error while doenloading movie information: {ex.Message} \n\t {ex.StackTrace} \n\t {ex.HResult}");
        }
        return null;
    }
}