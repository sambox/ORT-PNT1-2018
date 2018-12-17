using ejemplo.Models;
using ejemplo.Services;
using System;
using System.Web.Mvc;

namespace ejemplo.Controllers {
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
            PrestamoViewModel pvm = new PrestamoViewModel();
            pvm.lista = PrestamoService.findNoDevueltos();
            return View(pvm);
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
            pvm.fechaDevolucionReal = pvmMod.fechaDevolucionReal;
            pvm.fechaDevolucionTope = pvmMod.fechaDevolucionTope;
            return View(pvm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Modificar(PrestamoViewModel pvm)
        {
            pvm.fechaDevolucionTope = pvm.fechaPrestamo.AddDays(Prestamo.DIAS_PRESTAMO);
            PrestamoService.update(pvm);
            return volverAlListado();
        }

        public ActionResult Devolver(int prestamoId)
        {
            PrestamoService.devolver(prestamoId);
            return volverAlListadoNoDevueltos();
        }

        public ActionResult PrestamoPorDNI()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PrestamoPorDNI(int numeroDocumento)
        {
            PrestamoViewModel pvm = new PrestamoViewModel();
            pvm.lista = PrestamoService.findByNumeroDocumento(numeroDocumento);
            return View(pvm);
        }

        public ActionResult PrestamoPorLibro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PrestamoPorLibro(String titulo)
        {
            PrestamoViewModel pvm = new PrestamoViewModel();
            pvm.lista = PrestamoService.findByTitulo(titulo);
            return View(pvm);
        }

        private ActionResult volverAlListado()
        {
            return RedirectToAction("Listar", "Prestamo");
        }

        private ActionResult volverAlListadoNoDevueltos()
        {
            return RedirectToAction("ListarNoDevueltos", "Prestamo");
        }
    }
}