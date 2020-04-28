using System;
using EFTask.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFTask.Api.Models
{
    public partial class StudentiContext : DbContext
    {
        public StudentiContext()
        {
        }

        public StudentiContext(DbContextOptions<StudentiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Predmeti> Predmeti { get; set; }
        public virtual DbSet<PredmetiStudenti> PredmetiStudenti { get; set; }
        public virtual DbSet<Studenti> Studenti { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Predmeti>(entity =>
            {
                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsFixedLength();
            });

            modelBuilder.Entity<PredmetiStudenti>(entity =>
            {
                entity.HasKey(e => new { e.IdPredmeta, e.IdStudenta })
                    .HasName("PK__Predmeti__9DEEF4D19C9F55DF");

                entity.HasOne(d => d.IdPredmetaNavigation)
                    .WithMany(p => p.PredmetiStudenti)
                    .HasForeignKey(d => d.IdPredmeta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PredmetiStudenti_Predmeti");

                entity.HasOne(d => d.IdStudentaNavigation)
                    .WithMany(p => p.PredmetiStudenti)
                    .HasForeignKey(d => d.IdStudenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PredmetiStudenti_Studenti");
            });

            modelBuilder.Entity<Studenti>(entity =>
            {
                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
