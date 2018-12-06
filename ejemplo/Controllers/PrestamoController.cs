using ejemplo.Models;
using ejemplo.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ejemplo.Controllers {
    public class PrestamoController : Controller {
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

        [HttpPost]
        public ActionResult NuevoPrestamo(PrestamoViewModel pvm)
        {
            PrestamoService.add(pvm);
            /*using (var ctx = new BibliotecaContext())
            {
                List<Prestamo> p = new List<Prestamo>();
                Usuario u = new Usuario("dni",12345678,"Julian","Julian", "ju@ort.com","1234","CABA","ort",1,45961234, p);
                List<String> autores = new List<String>();
                autores.Add("Jorge Luis Borges");
                List<String> generos = new List<String>();
                generos.Add("Novela");
                Libro l = new Libro("ort", autores, generos,"qwer-qwer-qwer-qwer", 2);
                var prest = new Prestamo(false, new DateTime(2018, 11, 21), new DateTime(2018, 11, 21), 
                    u, l) ;
        
                ctx.Prestamos.Add(prest);
                ctx.SaveChanges();                
            }*/
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