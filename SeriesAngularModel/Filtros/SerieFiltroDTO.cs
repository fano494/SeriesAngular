using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeriesAngularModel.Filtros
{
    public class SerieFiltroDTO
    {
        public Nullable<int> idserie { get; set; }

        public string seriename { get; set; }

        public Nullable<decimal> score { get; set; }

        public string image { get; set; }
    }
}