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
    public class AdminProductoController : Controller
    {
        private GameStoreEntities db = new GameStoreEntities();

        // GET: AdminProducto
        public ActionResult Index()
        {
            var tB_Producto = db.TB_Producto.Include(t => t.TB_Categoria);
            return View(tB_Producto.ToList());
        }

        // GET: AdminProducto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Producto tB_Producto = db.TB_Producto.Find(id);
            if (tB_Producto == null)
            {
                return HttpNotFound();
            }
            return View(tB_Producto);
        }

        // GET: AdminProducto/Create
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.TB_Categoria, "idCategoria", "nomCategoria");
            return View();
        }

        // POST: AdminProducto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProd,nomProd,precio,descripcion,foto,idCategoria,stock")] TB_Producto tB_Producto)
        {
            if (ModelState.IsValid)
            {
                db.TB_Producto.Add(tB_Producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.TB_Categoria, "idCategoria", "nomCategoria", tB_Producto.idCategoria);
            return View(tB_Producto);
        }

        // GET: AdminProducto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Producto tB_Producto = db.TB_Producto.Find(id);
            if (tB_Producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.TB_Categoria, "idCategoria", "nomCategoria", tB_Producto.idCategoria);
            return View(tB_Producto);
        }

        // POST: AdminProducto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProd,nomProd,precio,descripcion,foto,idCategoria,stock")] TB_Producto tB_Producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_Producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoria = new SelectList(db.TB_Categoria, "idCategoria", "nomCategoria", tB_Producto.idCategoria);
            return View(tB_Producto);
        }

        // GET: AdminProducto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Producto tB_Producto = db.TB_Producto.Find(id);
            if (tB_Producto == null)
            {
                return HttpNotFound();
            }
            return View(tB_Producto);
        }

        // POST: AdminProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_Producto tB_Producto = db.TB_Producto.Find(id);
            db.TB_Producto.Remove(tB_Producto);
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
