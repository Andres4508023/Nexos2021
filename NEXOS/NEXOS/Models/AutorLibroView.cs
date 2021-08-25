using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NEXOS.Models
{
    public class AutorLibroView
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public Nullable<System.DateTime> Año { get; set; }

        public string Genero { get; set; }
        public Nullable<int> NumeroPagina { get; set; }
        public string NombresAutor { get; set; }
        public int  IdAutor { get; set; }
    }
}