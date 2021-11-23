using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInformationDownloader.DataMapper;

public  class HtmlSearchPersonDto
{
    public long Id { get; set; }
    public HtmlKeysEnumerator.HtmlPersonKeys Name { get; set; }
    public string StartValue { get; set; }
    public string EndValue { get; set; }
    public string Value { get; set; }
}
