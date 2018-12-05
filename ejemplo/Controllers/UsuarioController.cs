using ejemplo.Models;
using ejemplo.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ejemplo.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Listar()
        {
            List<Usuario> u;
            using (var ctx = new BibliotecaContext())
            {
                u = ctx.Usuarios.ToList();
            }
            return View(UsuarioService.mapper(u));
        }

        public ActionResult NuevoUsuario()
        {
            @ViewBag.Title = "Nuevo Usuario";
            return View();
        }

        [HttpPost]
        public ActionResult NuevoUsuario(UsuarioViewModel nuvm)
        {
            @ViewBag.Title = "Nuevo Usuario";
            using (var ctx = new BibliotecaContext())
            {
                ctx.Usuarios.Add(new Usuario(nuvm.tipoDocumento, nuvm.numeroDocumento, nuvm.nombre, nuvm.apellido, nuvm.email, nuvm.password, nuvm.localidad, nuvm.calle, nuvm.numero, nuvm.telefono));
                ctx.SaveChanges();
            }
            return View();
        }

        public ActionResult Modificar(int UsuarioId)
        {
            Usuario u = UsuarioService.getUsuarioById(UsuarioId);
            return View(new UsuarioViewModel(u.UsuarioId, u.tipoDocumento, u.numeroDocumento, u.nombre, u.apellido, u.email, u.password, u.localidad, u.calle, u.numero, u.telefono));
        }

        [HttpPost]
        public ActionResult Modificar(UsuarioViewModel uvm)
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
            return volverAlListado();
        }

        public ActionResult Eliminar(int UsuarioId)
        {
            Usuario u = UsuarioService.getUsuarioById(UsuarioId);
            UsuarioViewModel uvm = new UsuarioViewModel();
            uvm.UsuarioId = UsuarioId;
            uvm.nombre = u.nombre;
            uvm.apellido = u.apellido;
            uvm.tipoDocumento = u.tipoDocumento;
            uvm.numeroDocumento = u.numeroDocumento;
            return View(uvm);
        }

        [HttpPost]
        public ActionResult EliminarAction(UsuarioViewModel uvm)
        {
            using (var ctx = new BibliotecaContext())
            {
                Usuario u = ctx.Usuarios.SingleOrDefault(b => b.UsuarioId == uvm.UsuarioId);
                ctx.Usuarios.Remove(u);
                ctx.SaveChanges();
            }
            return volverAlListado();
        }

        private ActionResult volverAlListado()
        {
            return RedirectToAction("Listar", "Usuario");
        }

        public ActionResult BuscarUsuario()
        {
            @ViewBag.Title = "Buscar Usuario";
            return View();
        }

    }
}