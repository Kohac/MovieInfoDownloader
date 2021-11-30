using System;
using System.Collections.Generic;

namespace MovieInformationDownloader.Entities
{
    public partial class Audio
    {
        public long Id { get; set; }
        public long MovieId { get; set; }
        public long PersonId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
