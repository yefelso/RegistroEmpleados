using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Empleadox.Models;

namespace Empleadox.Controllers
{
    public class Tb_empleadosController : Controller
    {
        private AdminDeEmpleadosEntities db = new AdminDeEmpleadosEntities();

        // GET: Tb_empleados
        public ActionResult Index()
        {
            return View(db.Tb_empleados.ToList());
        }

        // GET: Tb_empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_empleados tb_empleados = db.Tb_empleados.Find(id);
            if (tb_empleados == null)
            {
                return HttpNotFound();
            }
            return View(tb_empleados);
        }

        // GET: Tb_empleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tb_empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_empleado,nombre,apellido,correo,cargo,departamento,fecha_contratacion,salario,rango,curriculum")] Tb_empleados tb_empleados)
        {
            if (ModelState.IsValid)
            {
                db.Tb_empleados.Add(tb_empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_empleados);
        }

        // GET: Tb_empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_empleados tb_empleados = db.Tb_empleados.Find(id);
            if (tb_empleados == null)
            {
                return HttpNotFound();
            }
            return View(tb_empleados);
        }

        // POST: Tb_empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_empleado,nombre,apellido,correo,cargo,departamento,fecha_contratacion,salario,rango,curriculum")] Tb_empleados tb_empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_empleados);
        }

        // GET: Tb_empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_empleados tb_empleados = db.Tb_empleados.Find(id);
            if (tb_empleados == null)
            {
                return HttpNotFound();
            }
            return View(tb_empleados);
        }

        // POST: Tb_empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tb_empleados tb_empleados = db.Tb_empleados.Find(id);
            db.Tb_empleados.Remove(tb_empleados);
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