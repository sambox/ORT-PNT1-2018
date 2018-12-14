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
            PrestamoViewModel pvm = new PrestamoViewModel();
            pvm.lista = PrestamoService.findAll();
            return View(pvm);
        }
        public ActionResult ListarNoDevueltos()
        {
            return View();
        }
        public ActionResult NuevoPrestamo()
        {
            PrestamoViewModel pvm = PrestamoService.getFormData();
            return View(pvm);
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

        public ActionResult Modificar(int prestamoId)
        {
            PrestamoViewModel pvm = PrestamoService.getFormData();
            PrestamoViewModel pvmMod = PrestamoService.findById(prestamoId);
            pvm.LibroId = pvmMod.LibroId;
            pvm.UsuarioId = pvmMod.UsuarioId;
            pvm.fechaPrestamoString = pvmMod.fechaPrestamoString;
            // pasar las fechas para q capture el action
            return View(pvm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Modificar(PrestamoViewModel pvm)
        {
            PrestamoService.update(pvm);
            return volverAlListado();
        }

        public ActionResult PrestamoPorDNI()
        {
            return View();
        }
        public ActionResult PrestamoPorLibro()
        {
            return View();
        }

        private ActionResult volverAlListado()
        {
            return RedirectToAction("Listar", "Prestamo");
        }
    }
}