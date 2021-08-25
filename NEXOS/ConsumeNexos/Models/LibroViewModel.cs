using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeNexos.Models
{
    public class LibroViewModel
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public Nullable<System.DateTime> Año { get; set; }
        public string Genero { get; set; }
        public Nullable<int> NumeroPagina { get; set; }
        public Nullable<int> IdAutor { get; set; }
    }
}