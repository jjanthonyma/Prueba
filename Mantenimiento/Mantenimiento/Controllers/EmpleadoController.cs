using Mantenimiento.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mantenimiento.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            try
            {
                using (var db = new EmpresaEntities())
                {
                    List<Empleado> lista = db.Empleadoes.ToList(); //Estructura de Linq

                    return View(lista);
                }
            }
            catch (Exception)
            {

                throw;
            }

          
        }

        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Empleado e)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                using (var db = new EmpresaEntities())
                {
                    e.fechaIngreso = DateTime.Now;
                    db.Empleadoes.Add(e);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al crear el empleado - "+  ex);
                return View();

            }

        }
        public ActionResult Editar(int id)
        {
            using (var db = new EmpresaEntities())
            {
                Empleado e = db.Empleadoes.Find(id);
                return View(e);

            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Empleado e)
        {
            try
            {
                using (var db = new EmpresaEntities())
                {
                    Empleado em = db.Empleadoes.Find(e.idempleado);
                    em.nombre = e.nombre;
                    em.apellido = e.apellido;
                    em.dui = e.dui;
                    em.direccion = e.direccion;
                    em.telefono = e.telefono;
                    em.salario = e.salario;
                    em.idoficina = e.idoficina;
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
        public ActionResult Detalles(int id)
        {
            using (var db = new EmpresaEntities())
            {
                Empleado em = db.Empleadoes.Include("Oficina").Include("Oficina.Empleadoes").Where(a => a.idempleado == id).SingleOrDefault();
                return View(em);

            }
        }
        public ActionResult Eliminar(int id)
        {
            using (var db =new EmpresaEntities())
            {
                Empleado e = db.Empleadoes.Find(id);
                db.Empleadoes.Remove(e);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
        }
    }
}