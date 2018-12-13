using ejemplo.Models;
using ejemplo.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace ejemplo.Controllers {
    public class UsuarioController : Controller {
        public ActionResult Listar()
        {
            UsuarioViewModel uvm = new UsuarioViewModel();
            uvm.lista = UsuarioService.findAll();
            return View(uvm);
        }

        public ActionResult NuevoUsuario()
        {
            @ViewBag.Title = "Nuevo Usuario";
            return View();
        }

        [HttpPost]
        public ActionResult NuevoUsuario(UsuarioViewModel uvm)
        {
            @ViewBag.Title = "Nuevo Usuario";
            UsuarioService.add(uvm);
            return volverAlListado();
        }

        public ActionResult Modificar(int UsuarioId)
        {
            return View(UsuarioService.findById(UsuarioId));
        }

        [HttpPost]
        public ActionResult Modificar(UsuarioViewModel uvm)
        {
            UsuarioService.update(uvm);
            return volverAlListado();
        }

        public ActionResult Eliminar(int UsuarioId)
        {
            return View(UsuarioService.findById(UsuarioId));
        }

        [HttpPost]
        public ActionResult Eliminar(UsuarioViewModel uvm)
        {
            UsuarioService.remove(uvm.UsuarioId);
            return volverAlListado();
        }

        private ActionResult volverAlListado()
        {
            return RedirectToAction("Listar", "Usuario");
        }

        public ActionResult BuscarUsuario()
        {
            @ViewBag.Title = "Buscar Usuario";
            return View();
        }

        [HttpPost]
        public ActionResult BuscarUsuario(UsuarioViewModel uvm)
        {
            @ViewBag.Title = "Buscar Usuario por número de documento";
            uvm.lista = UsuarioService.findByNumeroDocumento(uvm.numeroDocumento);
            return View(uvm);
        }

    }
}