using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinedostava.DTOModeli
{
	public class ProizvodiPorudzbineDTO
	{
		int id;
		string ime;
		string sastojci;
		int cena;
		int kolicina;
		PorudzbinaDTO porudzbina;
		int idporudzbine;

		public int Id { get => id; set => id = value; }
		public string Ime { get => ime; set => ime = value; }
		public string Sastojci { get => sastojci; set => sastojci = value; }
		public int Cena { get => cena; set => cena = value; }
		public int Kolicina { get => kolicina; set => kolicina = value; }
		public PorudzbinaDTO Porudzbina { get => porudzbina; set => porudzbina = value; }
		public int Idporudzbine { get => idporudzbine; set => idporudzbine = value; }

		public ProizvodiPorudzbineDTO(int id, string ime, string sastojci, int cena, int kolicina, int idporudzbine)
		{
			this.Id = id;
			this.Ime = ime;
			this.Sastojci = sastojci;
			this.Cena = cena;
			this.Kolicina = kolicina;
			this.Idporudzbine = idporudzbine;
		}
		public ProizvodiPorudzbineDTO()
		{

		}
	}
}
