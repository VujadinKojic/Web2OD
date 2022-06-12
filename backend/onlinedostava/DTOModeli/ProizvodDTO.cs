using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinedostava.DTOModeli
{
	public class ProizvodDTO
	{
		int id;
		string ime;
		string sastojci;
		int cena;

		public int Id { get => id; set => id = value; }
		public string Ime { get => ime; set => ime = value; }
		public string Sastojci { get => sastojci; set => sastojci = value; }
		public int Cena { get => cena; set => cena = value; }

		public ProizvodDTO(int id, string ime, string sastojci, int cena)
		{
			this.Id = id;
			this.Ime = ime;
			this.Sastojci = sastojci;
			this.Cena = cena;
		}

		public ProizvodDTO()
		{

		}
	}
}
