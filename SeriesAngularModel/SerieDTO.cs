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

        public string Imagen { get; set; }

        public float Puntuacion { get; set; }

        public SerieDTO(int id, string nom, string des, string img, float pun)
        {
            Id = id;
            Nombre = nom;
            Descripcion = des;
            Imagen = img;
            Puntuacion = pun;
        }
    }
}