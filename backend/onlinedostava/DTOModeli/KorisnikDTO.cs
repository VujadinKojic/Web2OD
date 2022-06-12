using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinedostava.DTOModeli
{
	public class KorisnikDTO
	{
		int id;
		string korime;
		string email;
		string lozinka;
		string ime;
		string prezime;
		string rodjenje;
		string adresa;
		string slika;
		string tipkorisnika;
		string statuskorisnika;
		ICollection<PorudzbinaDTO> porudzbine;

		public KorisnikDTO(int id, string korime, string email, string lozinka, string ime, string prezime, string rodjenje, string adresa, string slika, string tipkorisnika, string statuskorisnika)
		{
			this.id = id;
			this.korime = korime;
			this.email = email;
			this.lozinka = lozinka;
			this.ime = ime;
			this.prezime = prezime;
			this.rodjenje = rodjenje;
			this.adresa = adresa;
			this.slika = slika;
			this.tipkorisnika = tipkorisnika;
			this.statuskorisnika = statuskorisnika;
		}

		public KorisnikDTO()
		{

		}

		public int Id { get => id; set => id = value; }
		public string Korime { get => korime; set => korime = value; }
		public string Email { get => email; set => email = value; }
		public string Lozinka { get => lozinka; set => lozinka = value; }
		public string Ime { get => ime; set => ime = value; }
		public string Prezime { get => prezime; set => prezime = value; }
		public string Rodjenje { get => rodjenje; set => rodjenje = value; }
		public string Adresa { get => adresa; set => adresa = value; }
		public string Slika { get => slika; set => slika = value; }
		public string Tipkorisnika { get => tipkorisnika; set => tipkorisnika = value; }
		public string Statuskorisnika { get => statuskorisnika; set => statuskorisnika = value; }

	}
}
