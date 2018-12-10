using ejemplo.Models;
using ejemplo.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ejemplo.Controllers
{
    public class PrestamoController : Controller
    {
        // GET: Prestamo
        public ActionResult Listar()
        {
            return View(PrestamoService.findAll());
        }
        public ActionResult ListarNoDevueltos()
        {
            return View();
        }
        public ActionResult NuevoPrestamo()
        {
            return View(PrestamoService.getFormData());
        }

        [HttpPost,
         ValidateAntiForgeryToken]
        public ActionResult NuevoPrestamo(PrestamoViewModel pvm)
        {
            if (ModelState.IsValid)
            {
                PrestamoService.add(pvm);
                return RedirectToAction("Listar");
            }
            return View(PrestamoService.getFormData());
        }

        public ActionResult PrestamoPorDNI()
        {
            return View();
        }
        public ActionResult PrestamoPorLibro()
        {
            return View();
        }


    }
}