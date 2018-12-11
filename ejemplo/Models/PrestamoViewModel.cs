using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ejemplo.Models
{

    public class PrestamoViewModel
    {
        // para model to view
        // [Required]
        public int PrestamoId { get; set; }
        public bool devuelto { get; set; }
        public String fechaPrestamoString { get; set; }
        [Display(Name = "Fecha Prestamo"),
         Required(ErrorMessage = "Es obligaotrio seleccionar una fecha")]
        public DateTime fechaPrestamo { get; set; }
        public String fechaDevolucionString { get; set; }
        public DateTime fechaDevolucion { get; set; }
        [Display(Name = "Usuario"),
         Required(ErrorMessage = "Es obligaotrio seleccionar un usuario")]
        public int UsuarioId { get; set; }
        public Usuario usuario { get; set; }
        [Display(Name = "Libro"),
         Required(ErrorMessage = "Es obligaotrio seleccionar un libro")]
        public int LibroId { get; set; }
        public Libro libro { get; set; }
        public List<UsuarioViewModel> usuarios { get; set; }
        public List<LibroViewModel> libros { get; set; }
        public List<PrestamoViewModel> lista;

        public PrestamoViewModel(int prestamoId, bool devuelto, DateTime fechaPrestamo, DateTime fechaDevolucion)
        {
            this.PrestamoId = prestamoId;
            this.devuelto = devuelto;
            this.fechaPrestamo = fechaPrestamo;
            this.fechaDevolucion = fechaDevolucion;
        }

        public PrestamoViewModel() { }

    }
}