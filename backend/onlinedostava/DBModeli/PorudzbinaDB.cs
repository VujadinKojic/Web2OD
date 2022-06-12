using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace onlinedostava.DBModeli
{
	[Table("porudzbine", Schema = "db")]
	public class PorudzbinaDB
	{
		[Key]
		int id;
		string adresa;
		string komentar;
		double cena;
		int vremedostave;
		bool prihvacena;
		string vremeprihvatanja;
		[ForeignKey("korisnik")]
		int korisnikovId;
		ICollection<ProizvodiPorudzbineDB> proizvodi;
		int idDostavljaca;
		[ForeignKey("korisnikovId")]
		KorisnikDB korisnik;

		public PorudzbinaDB(int id, string adresa, string komentar, double cena, int vremedostave, bool prihvacena, string vremeprihvatanja, int korisnikovId, ICollection<ProizvodiPorudzbineDB> proizvodi, int idDostavljaca)
		{
			this.Id = id;
			this.Adresa = adresa;
			this.Komentar = komentar;
			this.Cena = cena;
			this.Vremedostave = vremedostave;
			this.Prihvacena = prihvacena;
			this.Vremeprihvatanja = vremeprihvatanja;
			this.KorisnikovId = korisnikovId;
			this.Proizvodi = proizvodi;
			this.idDostavljaca = idDostavljaca;
		}

		public PorudzbinaDB()
		{

		}
		public int Id { get => id; set => id = value; }
		public string Adresa { get => adresa; set => adresa = value; }
		public string Komentar { get => komentar; set => komentar = value; }
		public double Cena { get => cena; set => cena = value; }
		public int Vremedostave { get => vremedostave; set => vremedostave = value; }
		public bool Prihvacena { get => prihvacena; set => prihvacena = value; }
		public string Vremeprihvatanja { get => vremeprihvatanja; set => vremeprihvatanja = value; }
		public int KorisnikovId { get => korisnikovId; set => korisnikovId = value; }
		public ICollection<ProizvodiPorudzbineDB> Proizvodi { get => proizvodi; set => proizvodi = value; }
		public int IdDostavljaca { get => idDostavljaca; set => idDostavljaca = value; }
		public KorisnikDB Korisnik { get => korisnik; set => korisnik = value; }
	}
}
