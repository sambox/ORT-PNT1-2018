using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemplo.Models
{
    public class UsuarioViewModel
    {
        public int UsuarioId { get; set; }
        public String tipoDocumento { get; set; }
        public int numeroDocumento { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public String localidad { get; set; }
        public String calle { get; set; }
        public int numero { get; set; }
        public int telefono { get; set; }
        public List<UsuarioViewModel> lista { get; set; }
        public string nombreApellido { get; set; }
        public string tipoNumeroDocumento { get; set; }


        public UsuarioViewModel(int usuarioId, string tipoDocumento, int numeroDocumento, string nombre,
            string apellido, string email, string password, string localidad, string calle, int numero, int telefono)
        {
            this.UsuarioId = usuarioId;
            this.tipoDocumento = tipoDocumento;
            this.numeroDocumento = numeroDocumento;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.password = password;
            this.localidad = localidad;
            this.calle = calle;
            this.numero = numero;
            this.telefono = telefono;
            this.nombreApellido = String.Format("{0} {1}", nombre, apellido);
            this.tipoNumeroDocumento = String.Format("{0} {1}", tipoDocumento, numeroDocumento.ToString());
        }

        public UsuarioViewModel(string tipoDocumento, int numeroDocumento, string nombre,
            string apellido, string email, string password, string localidad, string calle, int numero, int telefono)
        {
            this.tipoDocumento = tipoDocumento;
            this.numeroDocumento = numeroDocumento;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.password = password;
            this.localidad = localidad;
            this.calle = calle;
            this.numero = numero;
            this.telefono = telefono;
            this.nombreApellido = String.Format("{0} {1}", nombre, apellido);
        }

        public UsuarioViewModel()
        {
        }
    }
}