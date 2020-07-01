using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using APP_MVC_Datos.Model;

namespace APP_MVC_GStore.Controllers
{
    public class AdminCategoriaController : Controller
    {
        private GameStoreEntities db = new GameStoreEntities();

        // GET: AdminCategoria
        public ActionResult Index()
        {
            return View(db.TB_Categoria.ToList());
        }

        // GET: AdminCategoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Categoria tB_Categoria = db.TB_Categoria.Find(id);
            if (tB_Categoria == null)
            {
                return HttpNotFound();
            }
            return View(tB_Categoria);
        }

        // GET: AdminCategoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminCategoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCategoria,nomCategoria")] TB_Categoria tB_Categoria)
        {
            if (ModelState.IsValid)
            {
                db.TB_Categoria.Add(tB_Categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_Categoria);
        }

        // GET: AdminCategoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Categoria tB_Categoria = db.TB_Categoria.Find(id);
            if (tB_Categoria == null)
            {
                return HttpNotFound();
            }
            return View(tB_Categoria);
        }

        // POST: AdminCategoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCategoria,nomCategoria")] TB_Categoria tB_Categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_Categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_Categoria);
        }

        // GET: AdminCategoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Categoria tB_Categoria = db.TB_Categoria.Find(id);
            if (tB_Categoria == null)
            {
                return HttpNotFound();
            }
            return View(tB_Categoria);
        }

        // POST: AdminCategoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_Categoria tB_Categoria = db.TB_Categoria.Find(id);
            db.TB_Categoria.Remove(tB_Categoria);
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
