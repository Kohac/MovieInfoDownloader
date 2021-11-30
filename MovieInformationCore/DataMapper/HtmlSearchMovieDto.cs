namespace MovieInformationDownloader.DataMapper;
public class HtmlSearchMovieDto
{
    public long Id { get; set; }
    public HtmlKeysEnumerator.HtmlMovieKeys Name { get; set; }
    public string StartValue { get; set; }
    public string EndValue { get; set; }
    public string Value { get; set; }
    //public InnerHtmlSearchDto InnerHtmlSearchDto { get; set; }
}
//public class InnerHtmlSearchDto
//{
//    public string Name { get; set; }
//    public string StartValue { get; set; }
//    public string EndValue { get; set; }
//    public string Value { get; set; }
//}
