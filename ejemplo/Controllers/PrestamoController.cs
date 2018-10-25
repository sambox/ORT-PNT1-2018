using System;
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
            return View();
        }
        public ActionResult ListarNoDevueltos()
        {
            return View();
        }
        public ActionResult NuevoPrestamo()
        {
            return View();
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