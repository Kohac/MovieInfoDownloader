using System;
using System.Collections.Generic;

namespace MovieInformationDownloader.Entities
{
    public partial class Tag
    {
        public long Id { get; set; }
        public long MovieId { get; set; }
        public string Tag1 { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
