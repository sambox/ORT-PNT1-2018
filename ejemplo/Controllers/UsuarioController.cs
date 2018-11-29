
using ejemplo.Models;
using System.Web.Mvc;

namespace ejemplo.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Listar()
        {
            return View();
        }

        public ActionResult NuevoUsuario()
        {
            @ViewBag.Title = "Nuevo Usuario";
            return View();
        }

        [HttpPost]
        public ActionResult NuevoUsuario(NuevoUsuarioViewModel nuvm)
        {
            using (var ctx = new BibliotecaContext())
            {
                var usuario = new Usuario(nuvm.tipoDocumento, nuvm.numeroDocumento, nuvm.nombre, nuvm.apellido, nuvm.email, nuvm.password, nuvm.localidad, nuvm.calle, nuvm.numero, nuvm.telefono);
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
            return View();
        }

        public ActionResult BuscarUsuario()
        {
            @ViewBag.Title = "Buscar Usuario";
            return View();
        }


    }
}