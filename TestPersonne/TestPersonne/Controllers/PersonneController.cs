using System;
using System.Collections.Generic;
using System.Linq;
using TestPersonne.DAL;
using System.Web.Mvc;

namespace TestPersonne.Controllers
{
    public class PersonneController : Controller
    {
		private IPersonneRepository _personneRepository;
		public PersonneController()
		{
			_personneRepository = new PersonneRepository(new TestPersonneDbContext());
		}
		public PersonneController(IPersonneRepository personneRepository)
		{
			_personneRepository = personneRepository;
		}
		[HttpGet]
		public ActionResult Index()
		{
			var model = _personneRepository.GetAll();
			return View(model);
		}
		[HttpGet]
		public ActionResult AddPersonne()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddPersonne(Personne model)
		{
			if (ModelState.IsValid)
			{
				_personneRepository.Insert(model);
				_personneRepository.Save();
				return RedirectToAction("Index", "Personne");
			}
			return View();
		}
		[HttpGet]
		public ActionResult EditPersonne(int PersonneId)
		{
			Personne model = _personneRepository.GetById(PersonneId);
			return View(model);
		}
		[HttpPost]
		public ActionResult EditPersonne(Personne model)
		{
			if (ModelState.IsValid)
			{
				_personneRepository.Update(model);
				_personneRepository.Save();
				return RedirectToAction("Index", "Personne");
			}
			else
			{
				return View(model);
			}
		}
		[HttpGet]
		public ActionResult DeletePersonne(int PersonneId)
		{
			Personne model = _personneRepository.GetById(PersonneId);
			return View(model);
		}
		[HttpPost]
		public ActionResult Delete(int PersonneID)
		{
			_personneRepository.Delete(PersonneID);
			_personneRepository.Save();
			return RedirectToAction("Index", "Personne");
		}
	}
}