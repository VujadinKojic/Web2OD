﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using onlinedostava.KonfiguracijaBazePodataka;

namespace onlinedostava.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("onlinedostava.DBModeli.KorisnikDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Korime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lozinka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rodjenje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Slika")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Statuskorisnika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipkorisnika")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("korisnici", "db");
                });

            modelBuilder.Entity("onlinedostava.DBModeli.PorudzbinaDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Cena")
                        .HasColumnType("float");

                    b.Property<int>("IdDostavljaca")
                        .HasColumnType("int");

                    b.Property<string>("Komentar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("KorisnikovId")
                        .HasColumnType("int");

                    b.Property<bool>("Prihvacena")
                        .HasColumnType("bit");

                    b.Property<int>("Vremedostave")
                        .HasColumnType("int");

                    b.Property<string>("Vremeprihvatanja")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.ToTable("porudzbine", "db");
                });

            modelBuilder.Entity("onlinedostava.DBModeli.ProizvodDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sastojci")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("proizvodi", "db");
                });

            modelBuilder.Entity("onlinedostava.DBModeli.ProizvodiPorudzbineDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<int>("Idporudzbine")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int?>("PorudzbinaId")
                        .HasColumnType("int");

                    b.Property<string>("Sastojci")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PorudzbinaId");

                    b.ToTable("proizvodiporudzbina", "db");
                });

            modelBuilder.Entity("onlinedostava.DBModeli.PorudzbinaDB", b =>
                {
                    b.HasOne("onlinedostava.DBModeli.KorisnikDB", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("onlinedostava.DBModeli.ProizvodiPorudzbineDB", b =>
                {
                    b.HasOne("onlinedostava.DBModeli.PorudzbinaDB", "Porudzbina")
                        .WithMany("Proizvodi")
                        .HasForeignKey("PorudzbinaId");

                    b.Navigation("Porudzbina");
                });

            modelBuilder.Entity("onlinedostava.DBModeli.PorudzbinaDB", b =>
                {
                    b.Navigation("Proizvodi");
                });
#pragma warning restore 612, 618
        }
    }
}
