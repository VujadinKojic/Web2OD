using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace onlinedostava.Migrations
{
    public partial class migracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "db");

            migrationBuilder.CreateTable(
                name: "korisnici",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Korime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rodjenje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Tipkorisnika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Statuskorisnika = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_korisnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "proizvodi",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sastojci = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proizvodi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "porudzbine",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Komentar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cena = table.Column<double>(type: "float", nullable: false),
                    Vremedostave = table.Column<int>(type: "int", nullable: false),
                    Prihvacena = table.Column<bool>(type: "bit", nullable: false),
                    Vremeprihvatanja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnikovId = table.Column<int>(type: "int", nullable: false),
                    IdDostavljaca = table.Column<int>(type: "int", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_porudzbine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_porudzbine_korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalSchema: "db",
                        principalTable: "korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "proizvodiporudzbina",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sastojci = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    PorudzbinaId = table.Column<int>(type: "int", nullable: true),
                    Idporudzbine = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proizvodiporudzbina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_proizvodiporudzbina_porudzbine_PorudzbinaId",
                        column: x => x.PorudzbinaId,
                        principalSchema: "db",
                        principalTable: "porudzbine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_porudzbine_KorisnikId",
                schema: "db",
                table: "porudzbine",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_proizvodiporudzbina_PorudzbinaId",
                schema: "db",
                table: "proizvodiporudzbina",
                column: "PorudzbinaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "proizvodi",
                schema: "db");

            migrationBuilder.DropTable(
                name: "proizvodiporudzbina",
                schema: "db");

            migrationBuilder.DropTable(
                name: "porudzbine",
                schema: "db");

            migrationBuilder.DropTable(
                name: "korisnici",
                schema: "db");
        }
    }
}
