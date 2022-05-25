using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Semana09.Models;
namespace Semana09.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {

            if (Session["People"] == null)
            {
                List<Person> people = new List<Person>();
                people.Add(new Person { ID = 1, FirstName = "Gustavo", LastName = "Blanco", BirthDay = DateTime.Today, isTecsup = true });
                people.Add(new Person { ID = 2, FirstName = "Elsin ", LastName = "Vila", BirthDay = DateTime.Today, isTecsup = false });
                Session["People"] = people;
            }

            return View(Session["People"]);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(Person model)
        {
            try
            {
                if (Session["People"] == null)
                    Session["People"] = new List<Person>();
                // TODO: Add insert logic here
                model.ID = this.maxInt() + 1;
                ((List<Person>)Session["People"]).Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            var model = ((List<Person>)Session["People"]).Where(x => x.ID == id).FirstOrDefault();

            return View(model);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Person model)
        {
            try
            {
                // TODO: Add update logic here
                Person person = ((List<Person>)Session["People"]).Find(x => x.ID == id);
                person.FirstName = model.FirstName;
                person.LastName = model.LastName;
                person.BirthDay = model.BirthDay;
                person.isTecsup = model.isTecsup;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            var model = ((List<Person>)Session["People"]).Where(x => x.ID == id).FirstOrDefault();

            return View(model);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Person model)
        {
            try
            {
                // TODO: Add delete logic here
                var toRemove = ((List<Person>)Session["People"]).Find(x => x.ID == id);
                ((List<Person>)Session["People"]).Remove(toRemove);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private int maxInt() => ((List<Person>)Session["People"]).Max(x => x.ID);

    }
}