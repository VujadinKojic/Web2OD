using AutoMapper;
using onlinedostava.DBModeli;
using onlinedostava.DTOModeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinedostava.Maper
{
	public class Maperr : Profile
	{
		public Maperr()
		{
			CreateMap<KorisnikDB, KorisnikDTO>().ReverseMap();
			CreateMap<PorudzbinaDB, PorudzbinaDTO>().ReverseMap();
			CreateMap<ProizvodDB, ProizvodDTO>().ReverseMap();
			CreateMap<ProizvodiPorudzbineDB, ProizvodiPorudzbineDTO>().ReverseMap();
		}

	}
}
