using Superheroes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Superheroes.Controllers
{
    public class SuperheroController : Controller
    {
        ApplicationDbContext db;
        // GET: Superhero

        public SuperheroController()
        {
            db = new ApplicationDbContext();
        }           

        public ActionResult Index()
        {
            var superheroes = db.Superhero;
            return View(superheroes);
        }

        // GET: Superhero/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Superhero superhero = db.Superhero.Find(id);
            if (superhero == null)
            {
                return HttpNotFound();
            }
            return View(superhero);
        }

        // GET: Superhero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Superhero/Create
        [HttpPost]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                db.Superhero.Add(superhero);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Superhero superhero = db.Superhero.Find(id);
            if (superhero == null)
            {
                return HttpNotFound();
            }
            return View(superhero);
        }

        // POST: Superhero/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Name,Id,AlterEgo,PrimaryAbility,SecondAbility,Catchphrase")] Superhero superhero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(superhero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(superhero);
        }

        // GET: Superhero/Delete/5
        public ActionResult Delete(int? id)
        {
            Superhero superhero = db.Superhero.Find(id);
            return View();
        }

        // POST: Superhero/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Superhero superhero = db.Superhero.Find(id);
                db.Superhero.Remove(superhero);
                db.SaveChanges();
                return RedirectToAction("Index");

             
            }
            catch
            {
                return View();
            }
        }
    }
}
