using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using onlinedostava.DBModeli;
using onlinedostava.DTOModeli;
using onlinedostava.Interfejsi;
using onlinedostava.Maper;
using onlinedostava.Providers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace onlinedostava.Servisi
{
	public class KorisnickiProfilServis : IKorisnickiProfilServis
	{
		private readonly IMapper maper;
		private readonly IConfigurationSection secretKey;
		private readonly DbKorisnikProvider korisnikProvajder;
		private readonly NoviMaper novimaper;


		public KorisnickiProfilServis(IMapper maper, Microsoft.Extensions.Configuration.IConfiguration config)
		{
			this.maper = maper;
			this.secretKey = config.GetSection("SecretKey");
			this.korisnikProvajder = new DbKorisnikProvider();
			this.novimaper = new NoviMaper(this.maper);
		}

		public KorisnikDTO ApdejtujProfil(KorisnikDTO k)
		{
			throw new NotImplementedException();
		}

		private int DobaviKorIdIzTokena(IHeaderDictionary header)
		{
			var handler = new JwtSecurityTokenHandler();
			string authHeader = header["Authorization"];
			authHeader = authHeader.Replace("Bearer ", "");
			var jsonToken = handler.ReadToken(authHeader);
			var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
			var stringId = tokenS.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
			return int.Parse(stringId);
		}
		public KorisnikDTO PronadjiProfil(IHeaderDictionary header)
		{
			KorisnikDB k = null;
			if ((k = korisnikProvajder.PronadjiKorisnika(DobaviKorIdIzTokena(header)))== null){
				return null;
			}
			return novimaper.MapirajKoriusnikaDBuDTO(k);
		}
		
		private bool ValidirajKorisnika(KorisnikDB korisnik)
		{
			if (String.IsNullOrWhiteSpace(korisnik.Statuskorisnika) || korisnik.Slika.Length == 0 ||  String.IsNullOrWhiteSpace(korisnik.Korime) || String.IsNullOrWhiteSpace(korisnik.Lozinka) || String.IsNullOrWhiteSpace(korisnik.Prezime) || String.IsNullOrWhiteSpace(korisnik.Ime) || String.IsNullOrWhiteSpace(korisnik.Tipkorisnika))
			{
				return false;		
			}
			return true;
		}

		public KorisnikDTO RegistrujSe(KorisnikDTO k)
		{
			KorisnikDB korisnik = novimaper.MapirajKoriusnikaDTOuDB(k);
			if (!ValidirajKorisnika(korisnik))
			{
				return null;
			}
			korisnik.Lozinka = BCrypt.Net.BCrypt.HashPassword(korisnik.Lozinka);
			KorisnikDB kor;
			if ((kor = korisnikProvajder.DodajKorisnika(korisnik)) == null)
			{
				return null;
			}		
			return novimaper.MapirajKoriusnikaDBuDTO(kor);
		}

		private string NapraviToken(KorisnikDB login)
		{
			List<Claim> claims = new List<Claim>();
			claims.Add(new Claim(ClaimTypes.NameIdentifier, login.Id.ToString()));
			claims.Add(new Claim(ClaimTypes.AuthorizationDecision, login.Statuskorisnika));
			claims.Add(new Claim(ClaimTypes.Role, login.Tipkorisnika));

			SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretkeydfbbdfbdfbdnfgnfgsdhsrnrtjshawegerhstrtdbnsgfmnsrgmznssr srn"));
			var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
			var tokenOptions = new JwtSecurityToken(
				issuer: "http://localhost:61491", //url servera koji je izdao token
				claims: claims,
				expires: DateTime.Now.AddMinutes(20), //vazenje tokena u minutama
				signingCredentials: signinCredentials //kredencijali za potpis
			);
			string token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
			return token;
		}

		public string UlogujSe(KorisnikDTO k)
		{
			KorisnikDB korisnik = novimaper.MapirajKoriusnikaDTOuDB(k);
			
			KorisnikDB login = korisnikProvajder.ProvjeriPostojanje(korisnik);
			if (login != null && BCrypt.Net.BCrypt.Verify(korisnik.Lozinka, login.Lozinka))
			{
				string token = NapraviToken(login);
				return token;
			}
			return null;
		}


		private void PosaljiMejl(KorisnikDB k)
		{
			var smtpClient = new SmtpClient("smtp.gmail.com")
			{
				Port = 587,
				Credentials = new NetworkCredential("", ""),//mejl sifra
				EnableSsl = true,
			};
			//od koga kome
			smtpClient.Send("", "", "verification", "Your account is " + k.Statuskorisnika + ".");
		}
		public KorisnikDTO VerifikujProfil(KorisnikDTO k)
		{

			KorisnikDB korisnik = novimaper.MapirajKoriusnikaDTOuDB(k);

			KorisnikDB ret = korisnikProvajder.PromeniVerikovanost(korisnik);
			
			return novimaper.MapirajKoriusnikaDBuDTO(ret);
			

		}
	}
}
