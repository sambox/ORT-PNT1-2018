using ejemplo.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ejemplo.Services
{
    public class PrestamoService
    {
        public static List<PrestamoViewModel> mapper(List<Prestamo> ps)
        {
            List<PrestamoViewModel> pvms = new List<PrestamoViewModel>();
            foreach (var p in ps)
            {
                pvms.Add(new PrestamoViewModel(p.PrestamoId, p.devuelto, p.fechaPrestamo, p.fechaDevolucion));
            }
            return pvms;
        }

        public static PrestamoViewModel mapper(Prestamo p)
        {
            return new PrestamoViewModel(p.PrestamoId, p.devuelto, p.fechaPrestamo, p.fechaDevolucion);
        }

        public static Prestamo mapper(PrestamoViewModel pvm)
        {
            return new Prestamo(pvm.PrestamoId, pvm.devuelto, pvm.fechaPrestamo, pvm.fechaDevolucion, pvm.UsuarioId, pvm.LibroId);
        }

        public static void add(PrestamoViewModel pvm)
        {
            //Prestamo p = mapper(pvm);
            //p.usuario = UsuarioService.mapper(UsuarioService.findUsuarioById(pvm.UsuarioId));
            //p.usuario_UsuarioId = pvm.UsuarioId;
            //p.libro_LibroID = pvm.LibroId;
            //p.libro = LibroService.mapper(LibroService.findLibroById(pvm.LibroId));
            //p.fechaPrestamo = DateTime.ParseExact(pvm.fechaPrestamoString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //p.fechaDevolucion = new DateTime(1970, 12, 01);

            using (var ctx = new BibliotecaContext())
            {
                Prestamo p = mapper(pvm);
                p.fechaDevolucion = DateTime.MaxValue;
                ctx.Entry(p).State = EntityState.Added;
                //ctx.Prestamos.Add(p);
                ctx.SaveChanges();
            }

        }

        public static void update(PrestamoViewModel pvm)
        {
            using (var ctx = new BibliotecaContext())
            {
                Prestamo p = ctx.Prestamos.SingleOrDefault(b => b.PrestamoId == pvm.PrestamoId);
                if (p != null)
                {
                    p.devuelto = pvm.devuelto;
                    p.fechaDevolucion = pvm.fechaDevolucion;
                    p.fechaPrestamo = pvm.fechaPrestamo;
                    //p.usuario = pvm.usuario;
                    //p.libro = pvm.libro;
                    ctx.SaveChanges();
                }
            }
        }

        public static void remove(int PrestamoId)
        {
            using (var ctx = new BibliotecaContext())
            {
                Prestamo p = ctx.Prestamos.Where(b => b.PrestamoId == PrestamoId).FirstOrDefault();
                ctx.Prestamos.Remove(p);
                ctx.SaveChanges();
            }
        }

        public static PrestamoViewModel getFormData()
        {
            PrestamoViewModel pvm = new PrestamoViewModel();
            pvm.fechaPrestamo = DateTime.Now;
            pvm.usuarios = UsuarioService.findAll();
            pvm.libros = LibroService.findAll();
            return pvm;
        }

        public static List<PrestamoViewModel> findAll()
        {
            List<Prestamo> ps;
            using (var ctx = new BibliotecaContext())
            {
                //ps = ctx.Prestamos.Include(x => x.usuario).Include(x => x.libro).ToList();
                ps = ctx.Prestamos.ToList();
            }
            return mapper(ps);
        }
    }
}