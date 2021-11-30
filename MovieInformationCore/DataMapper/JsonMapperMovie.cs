using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInformationDownloader.DataMapper
{
    public class JsonMapperMovie
    {
        public ICollection<HtmlSearchMovieDto> HtmlPairKeys { get; set; }
    }
}
