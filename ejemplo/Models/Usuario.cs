using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemplo.Models
{
    public class Usuario
    {
        private String tipoDocumento;
        private int numeroDocumento;
        private String nombre;
        private String apellido;
        private String email;
        private String password;
        private String localidad;
        private String calle;
        private int numero;
        private int telefono;
        public List<Prestamo> prestamos;
    }
}