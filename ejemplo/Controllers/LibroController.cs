using ejemplo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ejemplo.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        public ActionResult Listar()
        {
            return View();
        }

        public ActionResult NuevoLibro()
        {
         

            return View();
        }

        [HttpPost]
        public ActionResult NuevoLibro(LibroViewModel libroView)
        {
            using (var ctx = new BibliotecaContext())
            {
                var libro = new Libro(
                    libroView.titulo, 
                    libroView.autor, 
                    libroView.genero, 
                    libroView.isbn, 
                    libroView.cantEjemplares
                );
                ctx.Libros.Add(libro);
                ctx.SaveChanges();
            }
            return View();
        }

        public ActionResult BuscarTitulo()
        {
            return View();
        }

        public ActionResult BuscarAutor()
        {
            return View();
        }
    }
}