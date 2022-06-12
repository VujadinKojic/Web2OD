using Microsoft.AspNetCore.Http;
using onlinedostava.DTOModeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinedostava.Interfejsi
{
	public interface IKorisnickiProfilServis
	{
		KorisnikDTO RegistrujSe(KorisnikDTO k);
		string UlogujSe(KorisnikDTO k);
		KorisnikDTO ApdejtujProfil(KorisnikDTO k);
		KorisnikDTO PronadjiProfil(IHeaderDictionary header);
		KorisnikDTO VerifikujProfil(KorisnikDTO k);
	}
}
