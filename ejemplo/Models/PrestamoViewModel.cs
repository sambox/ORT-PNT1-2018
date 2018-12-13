using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ejemplo.Models
{

    public class PrestamoViewModel
    {
        public int PrestamoId { get; set; }
        public bool devuelto { get; set; }
        public String fechaPrestamoString { get; set; }
        [Display(Name = "Fecha Prestamo"),
         Required(ErrorMessage = "Es obligatorio seleccionar una fecha")]
        public DateTime fechaPrestamo { get; set; }
        public String fechaDevolucionTopeString { get; set; }
        public DateTime fechaDevolucionTope { get; set; }
        public String fechaDevolucionRealString { get; set; }
        public DateTime fechaDevolucionReal { get; set; }
        [Display(Name = "Usuario"),
         Required(ErrorMessage = "Es obligaotrio seleccionar un usuario")]
        public int UsuarioId { get; set; }
        public UsuarioViewModel usuario { get; set; }
        [Display(Name = "Libro"),
         Required(ErrorMessage = "Es obligaotrio seleccionar un libro")]
        public int LibroId { get; set; }
        public LibroViewModel libro { get; set; }
        public List<UsuarioViewModel> usuarios { get; set; }
        public List<LibroViewModel> libros { get; set; }
        public List<PrestamoViewModel> lista;

        public PrestamoViewModel(int prestamoId, bool devuelto, DateTime fechaPrestamo, DateTime fechaDevolucionTope, DateTime fechaDevolucionReal, int usuarioId, int libroId)
        {
            this.PrestamoId = prestamoId;
            this.devuelto = devuelto;
            this.fechaPrestamo = fechaPrestamo;
            this.fechaDevolucionTope = fechaDevolucionTope;
            this.fechaDevolucionReal = fechaDevolucionReal;
            this.UsuarioId = usuarioId;
            this.LibroId = libroId;
        }

        public PrestamoViewModel() { }

    }
}