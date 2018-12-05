using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemplo.Models
{
    public class Usuario
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
        public List<Prestamo> prestamos { get; set; }

        public Usuario(int UsuarioId, string tipoDocumento, int numeroDocumento, string nombre, string apellido, string email, string password, string localidad, string calle, int numero, int telefono)
        {
            this.UsuarioId = UsuarioId;
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
        }

        public Usuario(string tipoDocumento, int numeroDocumento, string nombre, string apellido, string email, string password, string localidad, string calle, int numero, int telefono)
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
        }

        public Usuario()
        {
        }
    }
}