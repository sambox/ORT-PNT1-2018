using ejemplo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemplo.Services {
    public class LibroService {
        public static List<LibroViewModel> mapper(List<Libro> libros)
        {
            List<LibroViewModel> lvms = new List<LibroViewModel>();
            foreach (var l in libros)
            {
                lvms.Add(new LibroViewModel(l.LibroID, l.titulo, l.autor, l.isbn, l.genero, l.cantEjemplares));
            }
            return lvms;
        }

        public static LibroViewModel mapper(Libro l)
        {
            return new LibroViewModel(l.LibroID, l.titulo, l.autor, l.isbn, l.genero, l.cantEjemplares);
        }

        public static Libro mapper(LibroViewModel l)
        {
            return new Libro(l.LibroId, l.titulo, l.autor, l.isbn, l.genero, l.cantEjemplares);
        }

        public static Libro getLibroById(int LibroId)
        {
            Libro l;
            using (var ctx = new BibliotecaContext())
            {
                l = ctx.Libros.SingleOrDefault(b => b.LibroID == LibroId);
            }
            return l;
        }
    }
}