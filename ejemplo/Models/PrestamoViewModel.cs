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
        public List<Usuario> usuarios { get; set; }
        public List<Libro> libros { get; set; }

        // para view to model
        public int UsuarioId { get; set; }
        public int LibroId { get; set; }
        public int cantEjemplares { get; set; }
        public DateTime fechaPrestamo { get; set; }
    }
}