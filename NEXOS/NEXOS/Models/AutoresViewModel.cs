using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NEXOS.Models
{
    public class AutoresViewModel
    {
        public int IdAutor { get; set; }
        public string Nombres { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public string CiudadNacimiento { get; set; }
        public string Correo { get; set; }

    }
}