using ejemplo.Models;
using ejemplo.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ejemplo.Controllers {
    public class LibroController : Controller {
        // GET: Libro
        public ActionResult Listar()
        {
            LibroViewModel lvm = new LibroViewModel();
            lvm.lista = LibroService.findAll();
            return View(lvm);
        }

        public ActionResult NuevoLibro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevoLibro(LibroViewModel lvm)
        {
            LibroService.add(lvm);
            return volverAlListado();
        }

        public ActionResult Modificar(int LibroId)
        {
            return View(LibroService.findLibroById(LibroId));
        }

        [HttpPost]
        public ActionResult Modificar(LibroViewModel lvm)
        {
            LibroService.update(lvm);
            return volverAlListado();
        }

        public ActionResult Eliminar(int LibroId)
        {
            return View(LibroService.findLibroById(LibroId));
        }

        [HttpPost]
        public ActionResult EliminarAction(LibroViewModel lvm)
        {
            LibroService.remove(lvm.LibroId);
            return volverAlListado();
        }

        private ActionResult volverAlListado()
        {
            return RedirectToAction("Listar", "Libro");
        }

        public ActionResult BuscarTitulo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuscarTitulo(LibroViewModel lvm)
        {
            lvm.lista = LibroService.findLibroByTitulo(lvm.titulo);
            return View(lvm);
        }

        public ActionResult BuscarAutor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuscarAutor(LibroViewModel lvm)
        {
            lvm.lista = LibroService.findLibroByAutor(lvm.autor);
            return View(lvm);
        }
    }
}