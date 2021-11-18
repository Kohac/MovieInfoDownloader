using System;
using System.Collections.Generic;

namespace MovieInformationDownloader.Entities
{
    public partial class CinemaPremiere
    {
        public long Id { get; set; }
        public long MovieId { get; set; }
        public string Country { get; set; }
        public string InCinemaFrom { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
