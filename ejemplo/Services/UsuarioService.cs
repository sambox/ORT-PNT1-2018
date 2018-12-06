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
                uvms.Add(new UsuarioViewModel(u.UsuarioId, u.tipoDocumento, u.numeroDocumento, u.nombre, u.apellido, u.email, u.password, u.localidad, u.calle, u.numero, u.telefono));
            }
            return uvms;
        }

        public static UsuarioViewModel mapper(Usuario u)
        {
            return new UsuarioViewModel(u.UsuarioId, u.tipoDocumento, u.numeroDocumento, u.nombre, u.apellido, u.email, u.password, u.localidad, u.calle, u.numero, u.telefono);
        }

        public static Usuario mapper(UsuarioViewModel u)
        {
            return new Usuario(u.UsuarioId, u.tipoDocumento, u.numeroDocumento, u.nombre, u.apellido, u.email, u.password, u.localidad, u.calle, u.numero, u.telefono);
        }

        public static UsuarioViewModel findUsuarioById(int usuarioId)
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
                    u.calle = uvm.calle;
                    u.numero = uvm.numero;
                    u.localidad = uvm.localidad;
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
            List<Usuario> ul;
            using (var ctx = new BibliotecaContext())
            {
                ul = ctx.Usuarios.ToList();
            }
            return mapper(ul);
        }

        public static List<UsuarioViewModel> findByNumeroDocumento(int numeroDocumento)
        {
            List<Usuario> ul;
            using (var ctx = new BibliotecaContext())
            {
                ul = ctx.Usuarios.Where(x => x.numeroDocumento.CompareTo(numeroDocumento) > 0).ToList();
            }
            return mapper(ul);
        }
    }
}