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
           string titulo = libroView.Titulo;
                string autor = libroView.Autor;
                List<String> autores = new List<String>();
                autores.Add(autor);
                string Isbn = libroView.Isbn;
                string Genero = libroView.Genero;
                List<String> generos = new List<String>();
                autores.Add(Genero);
                int Ejemplares = libroView.Ejemplares;

                var libro = new Libro(titulo,autores,generos,Isbn,Ejemplares);

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