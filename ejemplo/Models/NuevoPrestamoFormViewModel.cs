using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ejemplo.Models
{
    public class NuevoPrestamoFormViewModel
    {
        [Required]
        public List<Usuario> usuarios { get; set; }
        public List<Libro> libros { get; set; }

        public NuevoPrestamoFormViewModel(List<Usuario> usuarios, List<Libro> libros)
        {
            this.usuarios = usuarios;
            this.libros = libros;
        }

        public NuevoPrestamoFormViewModel()
        {
        }

        public int libroID { get; set; }
    }
}