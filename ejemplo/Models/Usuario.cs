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

        public Usuario(int UsuarioId, string tipoDocumento, int numeroDocumento, string nombre, string apellido, string email)
        {
            this.UsuarioId = UsuarioId;
            this.tipoDocumento = tipoDocumento;
            this.numeroDocumento = numeroDocumento;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
        }

        public Usuario(string tipoDocumento, int numeroDocumento, string nombre, string apellido, string email)
        {
            this.tipoDocumento = tipoDocumento;
            this.numeroDocumento = numeroDocumento;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
        }

        public Usuario()
        {
        }
    }
}