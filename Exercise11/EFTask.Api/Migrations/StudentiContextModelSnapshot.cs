﻿// <auto-generated />
using EFTask.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFTask.Api.Migrations
{
    [DbContext(typeof(StudentiContext))]
    partial class StudentiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFTask.Api.Models.Predmeti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nchar(30)")
                        .IsFixedLength(true)
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Predmeti");
                });

            modelBuilder.Entity("EFTask.Api.Models.PredmetiStudenti", b =>
                {
                    b.Property<int>("IdPredmeta")
                        .HasColumnType("int");

                    b.Property<int>("IdStudenta")
                        .HasColumnType("int");

                    b.HasKey("IdPredmeta", "IdStudenta")
                        .HasName("PK__Predmeti__9DEEF4D19C9F55DF");

                    b.HasIndex("IdStudenta");

                    b.ToTable("PredmetiStudenti");
                });

            modelBuilder.Entity("EFTask.Api.Models.Studenti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nchar(20)")
                        .IsFixedLength(true)
                        .HasMaxLength(20);

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nchar(20)")
                        .IsFixedLength(true)
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Studenti");
                });

            modelBuilder.Entity("EFTask.Api.Models.PredmetiStudenti", b =>
                {
                    b.HasOne("EFTask.Api.Models.Predmeti", "IdPredmetaNavigation")
                        .WithMany("PredmetiStudenti")
                        .HasForeignKey("IdPredmeta")
                        .HasConstraintName("FK_PredmetiStudenti_Predmeti")
                        .IsRequired();

                    b.HasOne("EFTask.Api.Models.Studenti", "IdStudentaNavigation")
                        .WithMany("PredmetiStudenti")
                        .HasForeignKey("IdStudenta")
                        .HasConstraintName("FK_PredmetiStudenti_Studenti")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
