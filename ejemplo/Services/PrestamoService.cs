using ejemplo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace ejemplo.Services {
    public class PrestamoService {
        public static List<PrestamoViewModel> mapper(List<Prestamo> ps)
        {
            List<PrestamoViewModel> pvms = new List<PrestamoViewModel>();
            PrestamoViewModel pvm;
            foreach (var p in ps)
            {
                if (p != null)
                {
                    pvm = new PrestamoViewModel(p.PrestamoId, p.devuelto, p.fechaPrestamo, p.fechaDevolucionTope, p.fechaDevolucionReal, p.usuario_UsuarioId, p.libro_LibroID);
                    pvm.fechaPrestamoString = p.fechaPrestamo.ToString("dd/MM/yyyy");
                    pvm.fechaDevolucionTopeString = p.fechaDevolucionTope.ToString("dd/MM/yyyy");
                    pvm.fechaDevolucionRealString = p.fechaDevolucionReal.ToString("dd/MM/yyyy");
                    pvms.Add(pvm);
                }
            }
            return pvms;
        }

        public static PrestamoViewModel mapper(Prestamo p)
        {
            PrestamoViewModel pvm = null;
            if (p != null)
            {
                pvm = new PrestamoViewModel(p.PrestamoId, p.devuelto, p.fechaPrestamo, p.fechaDevolucionTope, p.fechaDevolucionReal, p.usuario_UsuarioId, p.libro_LibroID);
                pvm.fechaPrestamoString = p.fechaPrestamo.ToString("dd/MM/yyyy");
                pvm.fechaDevolucionTopeString = p.fechaDevolucionTope.ToString("dd/MM/yyyy");
                pvm.fechaDevolucionRealString = p.fechaDevolucionReal.ToString("dd/MM/yyyy");
            }
            return pvm;
        }


        public static Prestamo mapper(PrestamoViewModel pvm)
        {
            Prestamo p = null;
            if (pvm != null)
            {
                p = new Prestamo(pvm.PrestamoId, pvm.devuelto, pvm.fechaPrestamo, pvm.fechaDevolucionTope, pvm.fechaDevolucionReal, pvm.UsuarioId, pvm.LibroId);
            }
            return p;
        }

        public static void add(PrestamoViewModel pvm)
        {
            using (var ctx = new BibliotecaContext())
            {
                Prestamo p = mapper(pvm);
                p.fechaDevolucionTope = p.fechaPrestamo.AddDays(Prestamo.DIAS_PRESTAMO);
                p.fechaDevolucionReal = DateTime.MaxValue;
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
                    p.fechaDevolucionTope = pvm.fechaDevolucionTope;
                    p.fechaPrestamo = pvm.fechaPrestamo;
                    p.usuario_UsuarioId = pvm.UsuarioId;
                    p.libro_LibroID = pvm.LibroId;
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
                ps = ctx.Prestamos.ToList();
            }
            List<PrestamoViewModel> pvms = mapper(ps);
            foreach (var p in pvms)
            {
                p.usuario = UsuarioService.findById(p.UsuarioId);
                p.libro = LibroService.findById(p.LibroId);
            }
            return pvms;
        }
        public static PrestamoViewModel findById(int prestamoId)
        {
            Prestamo p;
            using (var ctx = new BibliotecaContext())
            {
                p = ctx.Prestamos.SingleOrDefault(b => b.PrestamoId == prestamoId);
            }
            return mapper(p);
        }
    }
}