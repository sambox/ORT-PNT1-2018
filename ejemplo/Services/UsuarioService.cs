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

        internal static Usuario getUsuarioById(int usuarioId)
        {
            Usuario u;
            using (var ctx = new BibliotecaContext())
            {
                u = ctx.Usuarios.SingleOrDefault(b => b.UsuarioId == usuarioId);
            }
            return u;
        }
    }
}