using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ejemplo.Models
{
    public class Prestamo
    {
        public int PrestamoId { get; set; }
        public bool devuelto { get; set; }
        public DateTime fechaPrestamo { get; set; }
        public DateTime fechaDevolucion { get; set; }
        public int libro_LibroID { get; set; }
        public int usuario_UsuarioId { get; set; }

        public Prestamo(int prestamoId, bool devuelto, DateTime fechaPrestamo, DateTime fechaDevolucion, int usuarioId, int libroId)
        {
            PrestamoId = prestamoId;
            this.devuelto = devuelto;
            this.fechaPrestamo = fechaPrestamo;
            this.fechaDevolucion = fechaDevolucion;
            this.usuario_UsuarioId = usuarioId;
            this.libro_LibroID = libroId;
        }

        public Prestamo(bool devuelto, DateTime fechaPrestamo, DateTime fechaDevolucion)
        {
            this.devuelto = devuelto;
            this.fechaPrestamo = fechaPrestamo;
            this.fechaDevolucion = fechaDevolucion;

        }

        public Prestamo()
        {

        }
    }
}