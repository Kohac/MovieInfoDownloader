using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MovieInformationDownloader.Entities;

namespace MovieInformationDownloader.Context
{
    public partial class MovieInfoContext : DbContext
    {
        public MovieInfoContext()
        {
        }

        public MovieInfoContext(DbContextOptions<MovieInfoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Audio> Audios { get; set; }
        public virtual DbSet<Camera> Cameras { get; set; }
        public virtual DbSet<CinemaPremiere> CinemaPremieres { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<OtherMovieName> OtherMovieNames { get; set; }
        public virtual DbSet<RelatedMovie> RelatedMovies { get; set; }
        public virtual DbSet<Scenario> Scenarios { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Template> Templates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["movieInfo"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("Actor");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Actors)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Actor_Movie");
            });

            modelBuilder.Entity<Audio>(entity =>
            {
                entity.ToTable("Audio");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Audios)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Audio_Movie");
            });

            modelBuilder.Entity<Camera>(entity =>
            {
                entity.ToTable("Camera");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Cameras)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Camera_Movie");
            });

            modelBuilder.Entity<CinemaPremiere>(entity =>
            {
                entity.ToTable("CinemaPremiere");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InCinemaFrom)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.CinemaPremieres)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CinemaPremiere_Movie");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Directors)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Directors_Movie");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Genre1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Genre");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Genres)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Genres_Movie");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AgeWarning).HasMaxLength(200);

                entity.Property(e => e.CountryOfOrigin).HasMaxLength(100);

                entity.Property(e => e.CreatedYear).HasMaxLength(50);

                entity.Property(e => e.Duration).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Rating)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<OtherMovieName>(entity =>
            {
                entity.ToTable("OtherMovieName");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.OtherMovieNames)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RelativeMovieName_Movie");
            });

            modelBuilder.Entity<RelatedMovie>(entity =>
            {
                entity.ToTable("RelatedMovie");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.RelatedMovies)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RelatedMovie_Movie");
            });

            modelBuilder.Entity<Scenario>(entity =>
            {
                entity.ToTable("Scenario");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Scenarios)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Scenario_Movie");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag");

                entity.Property(e => e.Tag1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Tag");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tag_Movie");
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.ToTable("Template");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Templates)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Template_Movie");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
