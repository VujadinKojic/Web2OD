using Microsoft.EntityFrameworkCore;
using onlinedostava.DBModeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinedostava.KonfiguracijaBazePodataka
{
	public class DataBaseContext:DbContext
	{
		public DbSet<KorisnikDB> korisnici { get; set; }
		public DbSet<ProizvodDB> proizvodi { get; set; }
		public DbSet<PorudzbinaDB> porudzbine { get; set; }
		public DbSet<ProizvodiPorudzbineDB> proizvodiPorudzbine { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=baza;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

			optionsBuilder.UseSqlServer(connectionString);
		}
	}
}
