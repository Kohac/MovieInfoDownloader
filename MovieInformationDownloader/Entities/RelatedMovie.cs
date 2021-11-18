using System;
using System.Collections.Generic;

namespace MovieInformationDownloader.Entities
{
    public partial class RelatedMovie
    {
        public long Id { get; set; }
        public long MovieId { get; set; }
        public long RelatedMovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
