using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeriesAngularModel.Filtros
{
    public class UsuarioFiltroDTO
    {
        public Nullable<int> iduser { get; set; }

        public string email { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public ICollection<SerieDTO> series { get; set; }
    }
}
