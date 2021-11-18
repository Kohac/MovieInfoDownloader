namespace MovieInformationDownloader.DataMapper;
public class HtmlSearchDto
{
    public long Id { get; set; }
    public HtmlKeysEnumerator.HtmlKeys Name { get; set; }
    public string StartValue { get; set; }
    public string EndValue { get; set; }
    public string Value { get; set; }
    //public InnerHtmlSearchDto InnerHtmlSearchDto { get; set; }
}
public class InnerHtmlSearchDto
{
    public string Name { get; set; }
    public string StartValue { get; set; }
    public string EndValue { get; set; }
    public string Value { get; set; }
}
