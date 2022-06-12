using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace onlinedostava.DBModeli
{
	[Table("proizvodiporudzbina", Schema = "db")]
	public class ProizvodiPorudzbineDB
	{
		[Key]
		int id;
		string ime;
		string sastojci;
		int cena;
		int kolicina;
		[ForeignKey("idporudzbine")]
		PorudzbinaDB porudzbina;
		[ForeignKey("porudzbina")]
		int idporudzbine;

		public int Id { get => id; set => id = value; }
		public string Ime { get => ime; set => ime = value; }
		public string Sastojci { get => sastojci; set => sastojci = value; }
		public int Cena { get => cena; set => cena = value; }
		public int Kolicina { get => kolicina; set => kolicina = value; }
		public PorudzbinaDB Porudzbina { get => porudzbina; set => porudzbina = value; }
		public int Idporudzbine { get => idporudzbine; set => idporudzbine = value; }

		public ProizvodiPorudzbineDB(int id, string ime, string sastojci, int cena, int kolicina, int idporudzbine)
		{
			this.Id = id;
			this.Ime = ime;
			this.Sastojci = sastojci;
			this.Cena = cena;
			this.Kolicina = kolicina;
			this.Idporudzbine = idporudzbine;
		}
		public ProizvodiPorudzbineDB()
		{

		}
	}
}
