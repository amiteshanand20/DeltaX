using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DeltaX.Entities
{
    public partial class DeltaXDBContext : DbContext
    {
        public DeltaXDBContext()
        {
        }

        public DeltaXDBContext(DbContextOptions<DeltaXDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblActor> TblActors { get; set; } = null!;
        public virtual DbSet<TblMaster> TblMasters { get; set; } = null!;
        public virtual DbSet<TblMovie> TblMovies { get; set; } = null!;
        public virtual DbSet<TblMovieDetail> TblMovieDetails { get; set; } = null!;
        public virtual DbSet<TblProducer> TblProducers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=AMITESH-PC\\SQLExpress;Database=DeltaXDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblActor>(entity =>
            {
                entity.HasKey(e => e.ActorId)
                    .HasName("PK__tblActor__57B3EA2B2C7D2F4F");

                entity.ToTable("tblActor");

                entity.Property(e => e.ActorId).HasColumnName("ActorID");

                entity.Property(e => e.ActorName).HasMaxLength(50);

                entity.Property(e => e.Bio)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");
            });

            modelBuilder.Entity<TblMaster>(entity =>
            {
                entity.HasKey(e => e.MasterId)
                    .HasName("PK__tblMaste__F6B782C4F471B384");

                entity.ToTable("tblMaster");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.MasterName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MasterType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMovie>(entity =>
            {
                entity.HasKey(e => e.MovieId)
                    .HasName("PK__tblMovie__4BD2943AB167478A");

                entity.ToTable("tblMovie");

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.Property(e => e.MovieName).HasMaxLength(50);

                entity.Property(e => e.ProducerId).HasColumnName("ProducerID");

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.TblMovies)
                    .HasForeignKey(d => d.ProducerId)
                    .HasConstraintName("FK_tblMovie_tblProducer");
            });

            modelBuilder.Entity<TblMovieDetail>(entity =>
            {
                entity.HasKey(e => e.MovieDetailsId)
                    .HasName("PK__tblMovie__66FA4D662A3915AB");

                entity.ToTable("tblMovieDetails");

                entity.Property(e => e.MovieDetailsId).HasColumnName("MovieDetailsID");

                entity.Property(e => e.ActorId).HasColumnName("ActorID");

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.TblMovieDetails)
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("FK_tblMovieDetails_tblActor");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.TblMovieDetails)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_tblMovieDetails_tblMovie");
            });

            modelBuilder.Entity<TblProducer>(entity =>
            {
                entity.HasKey(e => e.ProducerId)
                    .HasName("PK__tblProdu__133696B21BDE7FD8");

                entity.ToTable("tblProducer");

                entity.Property(e => e.ProducerId).HasColumnName("ProducerID");

                entity.Property(e => e.Bio)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.ProducerName).HasMaxLength(50);

                entity.Property(e => e.ProductionHouse)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
