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

        private static bool validarEjemplaresDisponibles(LibroViewModel lvm)
        {
            List<Prestamo> ps = findByLibroId(lvm.LibroId);
            return ps.Count() < lvm.cantEjemplares;
        }

        public static List<Prestamo> findByLibroId(int LibroId)
        {
            List<Prestamo> ps;
            using (var ctx = new BibliotecaContext())
            {
                ps = ctx.Prestamos.Where(p => p.libro_LibroID == LibroId).ToList();
            }
            return ps;
        }

        public static List<Prestamo> findByUsuarioId(int UsuarioId)
        {
            List<Prestamo> ps;
            using (var ctx = new BibliotecaContext())
            {
                ps = ctx.Prestamos.Where(p => p.usuario_UsuarioId == UsuarioId).ToList();
            }
            return ps;
        }

        public static PrestamoViewModel getFormData()
        {
            List<LibroViewModel> lvms = new List<LibroViewModel>();
            PrestamoViewModel pvm = new PrestamoViewModel();
            pvm.fechaPrestamo = DateTime.Now;
            pvm.usuarios = UsuarioService.findAll();
            foreach (var lvm in LibroService.findAll())
            {
                if (validarEjemplaresDisponibles(lvm))
                {
                    lvms.Add(lvm);
                }
            }
            pvm.libros = lvms;
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
            cargarDatos(pvms);
            return pvms;
        }

        private static void cargarDatos(List<PrestamoViewModel> pvms)
        {
            foreach (var p in pvms)
            {
                p.usuario = UsuarioService.findById(p.UsuarioId);
                p.libro = LibroService.findById(p.LibroId);
            }
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

        public static List<PrestamoViewModel> findNoDevueltos()
        {
            List<Prestamo> ps;
            using (var ctx = new BibliotecaContext())
            {
                ps = ctx.Prestamos.Where(b => b.devuelto == false).ToList();
            }
            List<PrestamoViewModel> pvms = mapper(ps);
            cargarDatos(pvms);
            return pvms;
        }

        public static void devolver(int prestamoId)
        {
            using (var ctx = new BibliotecaContext())
            {
                Prestamo p = ctx.Prestamos.SingleOrDefault(b => b.PrestamoId == prestamoId);
                if (p != null)
                {
                    p.devuelto = true;
                    p.fechaDevolucionReal = DateTime.Now;
                    ctx.SaveChanges();
                }
            }
        }

        public static List<PrestamoViewModel> findByNumeroDocumento(int numeroDocumento)
        {
            List<PrestamoViewModel> pvms;
            List<UsuarioViewModel> uvms = UsuarioService.findByNumeroDocumento(numeroDocumento);
            List<int> uIds = new List<int>();
            foreach (var u in uvms)
            {
                uIds.Add(u.UsuarioId);
            }
            List<Prestamo> ps;
            using (var ctx = new BibliotecaContext())
            {
                ps = ctx.Prestamos.Where(p => uIds.Contains(p.usuario_UsuarioId)).ToList();
            }
            pvms = mapper(ps);
            cargarDatos(pvms);
            return pvms;
        }

        public static List<PrestamoViewModel> findByTitulo(String titulo)
        {
            List<PrestamoViewModel> pvms;
            List<LibroViewModel> lvms = LibroService.findLibroByTitulo(titulo);
            List<int> lIds = new List<int>();
            foreach (var l in lvms)
            {
                lIds.Add(l.LibroId);
            }
            List<Prestamo> ps;
            using (var ctx = new BibliotecaContext())
            {
                ps = ctx.Prestamos.Where(p => lIds.Contains(p.libro_LibroID)).ToList();
            }
            pvms = mapper(ps);
            cargarDatos(pvms);
            return pvms;
        }
    }
}