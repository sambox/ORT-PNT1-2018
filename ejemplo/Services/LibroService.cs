using ejemplo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ejemplo.Services {
    public class LibroService {
        public static List<LibroViewModel> mapper(List<Libro> libros)
        {
            List<LibroViewModel> lvms = new List<LibroViewModel>();
            foreach (var l in libros)
            {
                if (l != null)
                {
                    lvms.Add(new LibroViewModel(l.LibroID, l.titulo, l.autor, l.isbn, l.genero, l.cantEjemplares));
                }
            }
            return lvms;
        }

        public static LibroViewModel mapper(Libro l)
        {
            LibroViewModel lvm = null;
            if (l != null)
            {
                lvm = new LibroViewModel(l.LibroID, l.titulo, l.autor, l.isbn, l.genero, l.cantEjemplares);
            }
            return lvm;
        }

        public static Libro mapper(LibroViewModel lvm)
        {
            Libro l = null;
            if(lvm != null)
            {
                l = new Libro(lvm.LibroId, lvm.titulo, lvm.autor, lvm.isbn, lvm.genero, lvm.cantEjemplares);
            }
            return l;
        }

        public static void add(LibroViewModel lvm)
        {
            using (var ctx = new BibliotecaContext())
            {
                ctx.Libros.Add(mapper(lvm));
                ctx.SaveChanges();
            }
        }

        public static void update(LibroViewModel lvm)
        {
            using (var ctx = new BibliotecaContext())
            {
                Libro l = ctx.Libros.SingleOrDefault(b => b.LibroID == lvm.LibroId);
                if (l != null)
                {
                    l.titulo = lvm.titulo;
                    l.autor = lvm.titulo;
                    l.isbn = lvm.isbn;
                    l.genero = lvm.genero;
                    l.cantEjemplares = lvm.cantEjemplares;
                    ctx.SaveChanges();
                }
            }
        }

        public static void remove(int LibroID)
        {
            using (var ctx = new BibliotecaContext())
            {
                Libro l = ctx.Libros.Where(b => b.LibroID == LibroID).FirstOrDefault();
                ctx.Libros.Remove(l);
                ctx.SaveChanges();
            }
        }

        public static List<LibroViewModel> findAll()
        {
            List<Libro> l;
            using (var ctx = new BibliotecaContext())
            {
                l = ctx.Libros.ToList();
            }
            return mapper(l);
        }

        public static LibroViewModel findById(int LibroId)
        {
            Libro l;
            using (var ctx = new BibliotecaContext())
            {
                l = ctx.Libros.SingleOrDefault(b => b.LibroID == LibroId);
            }
            return mapper(l);
        }

        public static List<LibroViewModel> findLibroByTitulo(String titulo)
        {
            List<Libro> l;
            using (var ctx = new BibliotecaContext())
            {
                l = ctx.Libros.Where(x=>x.titulo.ToLower().Contains(titulo.ToLower())).ToList();
            }
            return mapper(l);
        }

        public static List<LibroViewModel> findLibroByAutor(String autor)
        {
            List<Libro> l;
            using (var ctx = new BibliotecaContext())
            {
                l = ctx.Libros.Where(x => x.autor.ToLower().Contains(autor.ToLower())).ToList();
            }
            return mapper(l);
        }

    }
}