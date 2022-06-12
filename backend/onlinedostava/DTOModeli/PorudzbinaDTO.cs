using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinedostava.DTOModeli
{
	public class PorudzbinaDTO
	{
		int id;
		string adresa;
		string komentar;
		double cena;
		int vremedostave;
		bool prihvacena;
		string vremeprihvatanja;
		int korisnikovId;
		ICollection<ProizvodiPorudzbineDTO> proizvodi;
		int idDostavljaca;
		KorisnikDto korisnik;

		public PorudzbinaDTO(int id, string adresa, string komentar, double cena, int vremedostave, bool prihvacena, string vremeprihvatanja, int korisnikovId, ICollection<ProizvodiPorudzbineDTO> proizvodi, int idDostavljaca)
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

		public PorudzbinaDTO()
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
		public ICollection<ProizvodiPorudzbineDTO> Proizvodi { get => proizvodi; set => proizvodi = value; }
		public int IdDostavljaca { get => idDostavljaca; set => idDostavljaca = value; }
		public KorisnikDto Korisnik { get => korisnik; set => korisnik = value; }
	}
}
