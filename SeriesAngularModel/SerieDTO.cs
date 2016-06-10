using System;
using System.Collections.Generic;

namespace SeriesAngularModel
{
    public class SerieDTO
    {
        public Nullable<int> idserie { get; set; }

        public string seriename { get; set; }

        public string producer { get; set; }

        public int year { get; set; }

        public Nullable<decimal> score { get; set; }

        public string description { get; set; }

        public string director { get; set; }

        public string gender { get; set; }

        public string image { get; set; }

        public ICollection<ActorDTO> actores { get; set; }

        public ICollection<ComentarioDTO> comentarios { get; set; }
    }
}