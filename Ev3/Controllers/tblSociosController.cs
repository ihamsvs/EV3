using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ev3;

namespace Ev3.Controllers
{
    public class tblSociosController : Controller
    {
        private GymfitEntities db = new GymfitEntities();

        // GET: tblSocios
        public ActionResult Index()
        {
            return View(db.tblSocios.ToList());
        }

        // GET: tblSocios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSocios tblSocios = db.tblSocios.Find(id);
            if (tblSocios == null)
            {
                return HttpNotFound();
            }
            return View(tblSocios);
        }

        // GET: tblSocios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblSocios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Rut,Nombres,Apellidos,Telefono,Email,Edad,Estatura,Peso")] tblSocios tblSocios)
        {
            if (ModelState.IsValid)
            {
                db.tblSocios.Add(tblSocios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblSocios);
        }

        // GET: tblSocios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSocios tblSocios = db.tblSocios.Find(id);
            if (tblSocios == null)
            {
                return HttpNotFound();
            }
            return View(tblSocios);
        }

        // POST: tblSocios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Rut,Nombres,Apellidos,Telefono,Email,Edad,Estatura,Peso")] tblSocios tblSocios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSocios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblSocios);
        }

        // GET: tblSocios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSocios tblSocios = db.tblSocios.Find(id);
            if (tblSocios == null)
            {
                return HttpNotFound();
            }
            return View(tblSocios);
        }

        // POST: tblSocios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSocios tblSocios = db.tblSocios.Find(id);
            db.tblSocios.Remove(tblSocios);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
