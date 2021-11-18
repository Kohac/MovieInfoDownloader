using System;
using System.Collections.Generic;

namespace MovieInformationDownloader.Entities
{
    public partial class Movie
    {
        public Movie()
        {
            Actors = new HashSet<Actor>();
            Audios = new HashSet<Audio>();
            Cameras = new HashSet<Camera>();
            CinemaPremieres = new HashSet<CinemaPremiere>();
            Directors = new HashSet<Director>();
            Genres = new HashSet<Genre>();
            OtherMovieNames = new HashSet<OtherMovieName>();
            RelatedMovies = new HashSet<RelatedMovie>();
            Scenarios = new HashSet<Scenario>();
            Tags = new HashSet<Tag>();
            Templates = new HashSet<Template>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public string CountryOfOrigin { get; set; }
        public string CreatedYear { get; set; }
        public string Duration { get; set; }
        public string MovieContent { get; set; }
        public string AgeWarning { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<Audio> Audios { get; set; }
        public virtual ICollection<Camera> Cameras { get; set; }
        public virtual ICollection<CinemaPremiere> CinemaPremieres { get; set; }
        public virtual ICollection<Director> Directors { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<OtherMovieName> OtherMovieNames { get; set; }
        public virtual ICollection<RelatedMovie> RelatedMovies { get; set; }
        public virtual ICollection<Scenario> Scenarios { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Template> Templates { get; set; }
    }
}
