using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesAngularModel.PagedList
{
    public class PagedList<T>
    {
        public IList<T> PaginaActual { get; set; }

        public Estructura Estructura { get; set; }
    }
}
