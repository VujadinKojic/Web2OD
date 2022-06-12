using Microsoft.EntityFrameworkCore.ChangeTracking;
using onlinedostava.DBModeli;
using onlinedostava.KonfiguracijaBazePodataka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinedostava.Providers
{
	public class DbKorisnikProvider
	{
		public DbKorisnikProvider()
		{

		}

		public KorisnikDB DodajKorisnika(KorisnikDB k)
		{
			EntityEntry ret = null;
			using (var db = new DataBaseContext())
			{
				ret = db.korisnici.Add(k);
				db.SaveChanges();
			}
			return (KorisnikDB)ret.Entity;
		}

		public KorisnikDB ProvjeriPostojanje(KorisnikDB k)
		{
			KorisnikDB ret = null;
			using (var db = new DataBaseContext())
			{
				List<KorisnikDB> korisnici = db.korisnici.Where(a => a.Korime == k.Korime).ToList();
				if (korisnici.Count > 0)
				{
					ret = korisnici[0];
				}
			}
			return ret;
		}

		public KorisnikDB PronadjiKorisnika(int id)
		{
			KorisnikDB ret = null;
			using (var db = new DataBaseContext())
			{
				List<KorisnikDB> korisnici = db.korisnici.Where(a => a.Id == id).ToList();
				if (korisnici.Count > 0)
				{
					ret = korisnici[0];
				}
			}
			return ret;
		}

		public KorisnikDB PromeniVerikovanost(KorisnikDB k)
		{
			KorisnikDB ret = null;
			using (var db = new DataBaseContext())
			{
				ret = PronadjiKorisnika(k.Id);
				ret.Statuskorisnika = k.Statuskorisnika;
				db.korisnici.Update(ret);
				db.SaveChanges();
			}
			return ret;
			
		}
	}
}
