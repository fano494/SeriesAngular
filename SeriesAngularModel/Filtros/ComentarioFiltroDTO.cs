using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesAngularModel.Filtros
{
    class ComentarioFiltroDTO
    {
        public int iduser { get; set; }

        public int idserie { get; set; }

        public Nullable<System.DateTime> commentdate { get; set; }
    }
}
