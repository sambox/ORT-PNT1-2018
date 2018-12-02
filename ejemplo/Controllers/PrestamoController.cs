using ejemplo.Models;
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
            using (var ctx = new BibliotecaContext())
            {
                var lista = ctx.Prestamos.ToList();

            }
            return View();
        }
        public ActionResult ListarNoDevueltos()
        {
            return View();
        }
        public ActionResult NuevoPrestamo()
        {
            NuevoPrestamoViewModel npvm = new NuevoPrestamoViewModel();
            npvm.usuarios = getUsuarios();
            npvm.libros = getLibros();
            return View(npvm);
        }

        private List<Libro> getLibros()
        {
            List<Libro> libros;
            using (var ctx = new BibliotecaContext())
            {
                libros = ctx.Libros.ToList();
            }
            return libros;
        }

        private List<Usuario> getUsuarios()
        {
            List<Usuario> usuarios;
            using (var ctx = new BibliotecaContext())
            {
                usuarios = ctx.Usuarios.ToList();
            }
            return usuarios;
        }

        [HttpPost]
        public ActionResult NuevoPrestamo(NuevoPrestamoViewModel p)
        {
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