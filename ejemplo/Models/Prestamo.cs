using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ejemplo.Models
{
    public class Prestamo
    {
        public const double DIAS_PRESTAMO = 7;
        public int PrestamoId { get; set; }
        public bool devuelto { get; set; }
        public DateTime fechaPrestamo { get; set; }
        public DateTime fechaDevolucionReal { get; set; }
        public DateTime fechaDevolucionTope { get; set; }
        public int libro_LibroID { get; set; }
        public int usuario_UsuarioId { get; set; }

        public Prestamo(int prestamoId, bool devuelto, DateTime fechaPrestamo, DateTime fechaDevolucionTope, DateTime fechaDevolucionReal, int usuarioId, int libroId)
        {
            PrestamoId = prestamoId;
            this.devuelto = devuelto;
            this.fechaPrestamo = fechaPrestamo;
            this.fechaDevolucionTope = fechaDevolucionTope;
            this.fechaDevolucionReal = fechaDevolucionReal;
            this.usuario_UsuarioId = usuarioId;
            this.libro_LibroID = libroId;
        }

        public Prestamo(bool devuelto, DateTime fechaPrestamo, DateTime fechaDevolucionTope, DateTime fechaDevolucionReal)
        {
            this.devuelto = devuelto;
            this.fechaPrestamo = fechaPrestamo;
            this.fechaDevolucionTope = fechaDevolucionTope;
            this.fechaDevolucionReal = fechaDevolucionReal;

        }

        public Prestamo()
        {

        }
    }
}