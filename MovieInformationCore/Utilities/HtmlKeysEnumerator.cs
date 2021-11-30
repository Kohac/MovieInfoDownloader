using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInformationDownloader.Utilities
{
    public class HtmlKeysEnumerator
    {
        public enum HtmlMovieKeys
        {
            Name,
            Rating,
            Genres,
            Origin, //contains Original country, YearCreated and Duration
            Director,
            Template,
            Scenario,
            Camera,
            Audio,
            Actors,
            Content,
            OtherFilmNames,
            CinemaPremiere,
            AgeWarning,
            RelatedMovies,
            Tags
        }
        public enum HtmlPersonKeys
        {
            PersonalData,
            Biography
        }
    }
}
