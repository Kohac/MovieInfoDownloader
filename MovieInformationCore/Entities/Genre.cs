using System;
using System.Collections.Generic;

namespace MovieInformationDownloader.Entities
{
    public partial class Genre
    {
        public long Id { get; set; }
        public long MovieId { get; set; }
        public string Genre1 { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
