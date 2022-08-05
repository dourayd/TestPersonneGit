using System;
using System.Collections.Generic;
using TestPersonne.DAL;

namespace TestPersonne
{
	public class PersonneRepository : IPersonneRepository
	{
		private readonly TestPersonneDbContext _context;
		public PersonneRepository()
		{
			_context = new TestPersonneDbContext();
		}
		public PersonneRepository(TestPersonneDbContext context)
		{
			_context = context;
		}
		public IEnumerable<Personne> GetAll()
		{
			return _context.Personnes;
		}

		public Personne GetById(int PersonneID)
		{
			return _context.Personnes.Find(PersonneID);
		}
		public void Insert(Personne personne)
		{
			_context.Personnes.Add(personne);
		}
		public void Update(Personne personne)
		{
			_context.Entry(personne).State = System.Data.Entity.EntityState.Modified;
		}
		public void Delete(int personneID)
		{
			Personne personne = _context.Personnes.Find(personneID);
			_context.Personnes.Remove(personne);
		}
		public void Save()
		{
			_context.SaveChanges();
		}

		private bool disposed = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			this.disposed = true;
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}