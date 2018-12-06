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
        public DateTime fechaPrestamo { get; set; }
        public String fechaDevolucionString { get; set; }
        public DateTime fechaDevolucion { get; set; }
        public int UsuarioId { get; set; }
        public Usuario usuario { get; set; }
        public int LibroId { get; set; }
        public Libro libro { get; set; }
        public List<UsuarioViewModel> usuarios { get; set; }
        public List<LibroViewModel> libros { get; set; }

        public PrestamoViewModel()
        {
        }

    }
}