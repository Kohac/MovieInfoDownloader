using System;
using System.Collections.Generic;

namespace MovieInformationDownloader.Entities
{
    public partial class OtherMovieName
    {
        public long Id { get; set; }
        public long MovieId { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
