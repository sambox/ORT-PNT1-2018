using ejemplo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemplo.Services {
    public class UsuarioService {
        public static List<UsuarioViewModel> mapper(List<Usuario> usuarios)
        {
            List<UsuarioViewModel> uvms = new List<UsuarioViewModel>();
            foreach (var u in usuarios)
            {
                if(u != null)
                {
                    uvms.Add(new UsuarioViewModel(u.UsuarioId, u.tipoDocumento, u.numeroDocumento, u.nombre, u.apellido, u.email));
                }
            }
            return uvms;
        }

        public static UsuarioViewModel mapper(Usuario u)
        {
            UsuarioViewModel uvm = null;
            if( u != null)
            {
                uvm = new UsuarioViewModel(u.UsuarioId, u.tipoDocumento, u.numeroDocumento, u.nombre, u.apellido, u.email);
            }
            return uvm;
        }

        public static Usuario mapper(UsuarioViewModel uvm)
        {
            Usuario u = null;
            if(uvm != null)
            {
                u = new Usuario(uvm.UsuarioId, uvm.tipoDocumento, uvm.numeroDocumento, uvm.nombre, uvm.apellido, uvm.email);
            }
            return u;
        }

        public static UsuarioViewModel findById(int usuarioId)
        {
            Usuario u;
            using (var ctx = new BibliotecaContext())
            {
                u = ctx.Usuarios.SingleOrDefault(b => b.UsuarioId == usuarioId);
            }
            return mapper(u);
        }

        public static void add(UsuarioViewModel uvm)
        {
            using (var ctx = new BibliotecaContext())
            {
                ctx.Usuarios.Add(mapper(uvm));
                ctx.SaveChanges();
            }
        }

        public static void update(UsuarioViewModel uvm)
        {
            using (var ctx = new BibliotecaContext())
            {
                Usuario u = ctx.Usuarios.SingleOrDefault(b => b.UsuarioId == uvm.UsuarioId);
                if (u != null)
                {
                    u.nombre = uvm.nombre;
                    u.apellido = uvm.apellido;
                    u.tipoDocumento = uvm.tipoDocumento;
                    u.numeroDocumento = uvm.numeroDocumento;
                    u.email = uvm.email;
                    ctx.SaveChanges();
                }
            }
        }

        public static void remove(int UsuarioId)
        {
            using (var ctx = new BibliotecaContext())
            {
                Usuario u = ctx.Usuarios.SingleOrDefault(b => b.UsuarioId == UsuarioId);
                ctx.Usuarios.Remove(u);
                ctx.SaveChanges();
            }
        }

        public static List<UsuarioViewModel> findAll()
        {
            List<UsuarioViewModel> uvms;
            List<Usuario> ul;
            using (var ctx = new BibliotecaContext())
            {
                ul = ctx.Usuarios.ToList();
            }
            uvms = mapper(ul);
            verificarSiTienenPrestamos(uvms);
            return uvms;
        }

        private static void verificarSiTienenPrestamos(List<UsuarioViewModel> uvms)
        {
            foreach (var uvm in uvms)
            {
                if (PrestamoService.findByUsuarioId(uvm.UsuarioId).Count() > 0)
                {
                    uvm.tienePrestamos = true;
                }
            }
        }

        public static List<UsuarioViewModel> findByNumeroDocumento(int numeroDocumento)
        {
            List<Usuario> ul;
            using (var ctx = new BibliotecaContext())
            {
                ul = ctx.Usuarios.Where(x => x.numeroDocumento.ToString().Contains(numeroDocumento.ToString())).ToList();
            }
            return mapper(ul);
        }
    }
}