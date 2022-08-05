using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPersonne.DAL;

namespace TestPersonne
{
	public interface IPersonneRepository
	{
		IEnumerable<Personne> GetAll();
		Personne GetById(int PersonneID);
		void Insert(Personne personne);
		void Update(Personne personne);
		void Delete(int personneID);
		void Save();
	}
}
