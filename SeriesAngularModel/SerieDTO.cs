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

        public string Productor { get; set; }

        public int Ano { get; set; }

        public string Director { get; set; }

        public string Genero { get; set; }

        public string Imagen { get; set; }

        public float Puntuacion { get; set; }

        public SerieDTO(int id, string nom, string des, string pro, int ano, string dir, string gen, string img, float pun)
        {
            Id = id;
            Nombre = nom;
            Descripcion = des;
            Productor = pro;
            Ano = ano;
            Director = dir;
            Genero = gen;
            Imagen = img;
            Puntuacion = pun;
        }
    }
}