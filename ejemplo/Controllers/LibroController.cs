using ejemplo.Models;
using ejemplo.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ejemplo.Controllers {
    public class LibroController : Controller
    {
        // GET: Libro
        public ActionResult Listar()
        {
            List<Libro> l;
            using (var ctx = new BibliotecaContext())
            {
                l = ctx.Libros.ToList();
            }
            return View(l);
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
                ctx.Libros.Add(new Libro(libroView.titulo, libroView.autor, libroView.genero, libroView.isbn, libroView.cantEjemplares));
                ctx.SaveChanges();
            }
            return volverAlListado();
        }

        public ActionResult Modificar(int LibroId)
        {
            Libro l = LibroService.getLibroById(LibroId);
            LibroViewModel lvm = new LibroViewModel();
            lvm.autor = l.autor;
            lvm.cantEjemplares = l.cantEjemplares;
            lvm.titulo = l.titulo;
            lvm.genero = l.genero;
            lvm.isbn = l.isbn;
            lvm.LibroId = l.LibroID;
            return View(lvm);
        }

        [HttpPost]
        public ActionResult Modificar(LibroViewModel lv)
        {
            using (var ctx = new BibliotecaContext())
            {
                Libro l = ctx.Libros.SingleOrDefault(b => b.LibroID == lv.LibroId);
                if(l!=null)
                {
                    l.titulo = lv.titulo;
                    l.autor = lv.titulo;
                    l.isbn = lv.isbn;
                    l.genero = lv.genero;
                    l.cantEjemplares = lv.cantEjemplares;
                    ctx.SaveChanges();
                }
            }
            return volverAlListado();
        }

        public ActionResult Eliminar(int LibroId)
        {
            Libro l = LibroService.getLibroById(LibroId);
            LibroViewModel libroView = new LibroViewModel();
            libroView.LibroId = LibroId;
            libroView.titulo = l.titulo;
            libroView.autor = l.autor;
            return View(libroView);
        }

        [HttpPost]
        public ActionResult EliminarAction(LibroViewModel libroView)
        {
            using (var ctx = new BibliotecaContext())
            {
                Libro l = ctx.Libros.Where(b => b.LibroID == libroView.LibroId).FirstOrDefault();
                ctx.Libros.Remove(l);
                ctx.SaveChanges();
            }
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

        public ActionResult BuscarAutor()
        {
            return View();
        }
    }
}