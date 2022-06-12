using AutoMapper;
using onlinedostava.DBModeli;
using onlinedostava.DTOModeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlinedostava.Maper
{
	public class NoviMaper
	{
		private readonly IMapper maper;

		public NoviMaper(IMapper maper)
		{
			this.maper = maper;
		}

		public KorisnikDTO MapirajKoriusnikaDBuDTO(KorisnikDB korisnik)
		{
			KorisnikDTO kor2 = maper.Map<KorisnikDTO>(korisnik);
			kor2.Adresa = korisnik.Adresa;
			kor2.Email = korisnik.Email;
			kor2.Id = korisnik.Id;
			kor2.Ime = korisnik.Ime;
			kor2.Korime = korisnik.Korime;
			kor2.Lozinka = korisnik.Lozinka;
			kor2.Prezime = korisnik.Prezime;
			kor2.Rodjenje = korisnik.Rodjenje;
			kor2.Statuskorisnika = korisnik.Statuskorisnika;
			kor2.Tipkorisnika = korisnik.Tipkorisnika;
			kor2.Slika = Encoding.Default.GetString(korisnik.Slika);
			return kor2;
		}

		public KorisnikDB MapirajKoriusnikaDTOuDB(KorisnikDTO korisnik)
		{
			KorisnikDB kor2 = new KorisnikDB();
			kor2.Adresa = korisnik.Adresa;
			kor2.Email = korisnik.Email;
			kor2.Id = korisnik.Id;
			kor2.Ime = korisnik.Ime;
			kor2.Korime = korisnik.Korime;
			kor2.Lozinka = korisnik.Lozinka;
			kor2.Prezime = korisnik.Prezime;
			kor2.Rodjenje = korisnik.Rodjenje;
			kor2.Statuskorisnika = korisnik.Statuskorisnika;
			kor2.Tipkorisnika = korisnik.Tipkorisnika;
			kor2.Slika = Encoding.ASCII.GetBytes(korisnik.Slika);
			return kor2;
		}

	}
}
