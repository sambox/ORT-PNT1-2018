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
        [ForeignKey("usuario")]
        public virtual Usuario usuario { get; set; }
        [ForeignKey("libro")]
        public virtual Libro libro { get; set; }

        public Prestamo(int prestamoId, bool devuelto, DateTime fechaPrestamo, DateTime fechaDevolucion, Usuario usuario, Libro libro)
        {
            PrestamoId = prestamoId;
            this.devuelto = devuelto;
            this.fechaPrestamo = fechaPrestamo;
            this.fechaDevolucion = fechaDevolucion;
            this.usuario = usuario;
            this.libro = libro;
        }

        public Prestamo(bool devuelto, DateTime fechaPrestamo, DateTime fechaDevolucion, Usuario usuario, Libro libro)
        {
            this.devuelto = devuelto;
            this.fechaPrestamo = fechaPrestamo;
            this.fechaDevolucion = fechaDevolucion;
            this.usuario = usuario;
            this.libro = libro;
        }

        public Prestamo() {

        }
    }
}