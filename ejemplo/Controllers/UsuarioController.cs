
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ejemplo.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Listar()
        {
            return View();
        }

        public ActionResult NuevoUsuario()
        {
            @ViewBag.Title = "Nuevo Usuario";
            return View();
        }

        public ActionResult BuscarUsuario()
        {
            @ViewBag.Title = "Buscar Usuario";
            return View();
        }

    }
}