using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemplo.Models {
    public class LibroViewModel {
        public int LibroId { get; set; }
        public string titulo { get; set; }
        public string autor { get; set; }
        public string isbn { get; set; }
        public string genero { get; set; }
        public int cantEjemplares { get; set; }
        public List<LibroViewModel> lista { get; set; }

        public LibroViewModel(int libroId, string titulo, string autor, string isbn, string genero, int cantEjemplares)
        {
            LibroId = libroId;
            this.titulo = titulo;
            this.autor = autor;
            this.isbn = isbn;
            this.genero = genero;
            this.cantEjemplares = cantEjemplares;
            this.lista = new List<LibroViewModel>();
        }

        public LibroViewModel()
        {
        }
    }
}