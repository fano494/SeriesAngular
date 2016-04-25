using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeriesAngularModel
{
    public class SerieDTO
    {
        public Nullable<int> Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public SerieDTO(int i, string n, string d)
        {
            Id = i;
            Nombre = n;
            Descripcion = d;
        }
    }
}