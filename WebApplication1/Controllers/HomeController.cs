using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PeopleLinqToSql.Data;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var repo = new PeopleRepository(Properties.Settings.Default.ConStr);
            return View(repo.GetPeople());
        }

        [HttpPost]
        public ActionResult Add(Person person)
        {
            var repo = new PeopleRepository(Properties.Settings.Default.ConStr);
            repo.Add(person);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var repo = new PeopleRepository(Properties.Settings.Default.ConStr);
            return View(repo.GetById(id));
        }

        [HttpPost]
        public ActionResult Update(Person person)
        {
            var repo = new PeopleRepository(Properties.Settings.Default.ConStr);
            repo.Update(person);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var repo = new PeopleRepository(Properties.Settings.Default.ConStr);
            repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}