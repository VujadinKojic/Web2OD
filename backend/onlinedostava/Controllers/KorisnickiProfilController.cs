using Microsoft.AspNetCore.Mvc;
using onlinedostava.DTOModeli;
using onlinedostava.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinedostava.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class KorisnickiProfilController : ControllerBase
	{
		private readonly IKorisnickiProfilServis korisnickiprofilservis;

		public KorisnickiProfilController(IKorisnickiProfilServis korisnickiprofilservis)
		{
			this.korisnickiprofilservis = korisnickiprofilservis;
		}
		[HttpPost]
		[Route("registracija")]
		public IActionResult Registration(KorisnikDTO k)
		{
			KorisnikDTO kor = korisnickiprofilservis.RegistrujSe(k);
			return Ok(kor);
		}

		[HttpPost]
		[Route("login")]
		public IActionResult Login(KorisnikDTO k)
		{
			string token = korisnickiprofilservis.UlogujSe(k);
			return Ok(token);
		}

		[HttpPost]
		[Route("azurirajprofil")]
		public IActionResult AzurirajProfil(KorisnikDTO k)
		{
			KorisnikDTO kor = korisnickiprofilservis.ApdejtujProfil(k);
			return Ok(kor);
		}

		[HttpPost]
		[Route("pronadjiprofil")]
		public IActionResult PronadjiProfil()
		{
			KorisnikDTO kor = korisnickiprofilservis.PronadjiProfil(Request.Headers);
			return Ok(kor);
		}

		[HttpPost]
		[Route("verifikujkorisnika")]
		public IActionResult VerifikujKorisnika(KorisnikDTO k)
		{
			KorisnikDTO kor = korisnickiprofilservis.VerifikujProfil(k);
			return Ok(kor);
		}
	}
}
