using Mantenimiento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mantenimiento.Controllers
{
    public class OficinaController : Controller
    {
        // GET: Oficina
        public ActionResult Index()
        {
            try
            {
                using (var db = new EmpresaEntities())
                {
                    List<Oficina> lista = db.Oficinas.ToList(); //Estructura de Linq

                    return View(lista);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Detalles(int id)
        {
            using (var db = new EmpresaEntities())
            {
                Oficina em = db.Oficinas.Find(id);
                return View(em);

            }
        }


        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Oficina e)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                using (var db = new EmpresaEntities())
                {
                    db.Oficinas.Add(e);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al crear el empleado - " + ex);
                return View();

            }

        }
        public ActionResult Editar(int id)
        {
            using (var db = new EmpresaEntities())
            {
                Oficina e = db.Oficinas.Find(id);
                return View(e);

            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Oficina e)
        {
            try
            {
                using (var db = new EmpresaEntities())
                {
                    Oficina em = db.Oficinas.Find(e.idoficina);
                    em.nombreofi = e.nombreofi;
                    em.descripcion = e.descripcion;
                    em.direccion = e.direccion;
                    em.telefono = e.telefono;
                 
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error al crear el empleado - " + ex);
                return View();
            }
        }

    }
}