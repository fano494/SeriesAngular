using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesAngularModel.PagedList
{
    public static class Utils
    {
        public static PagedList<T> ToPagedList<T>(IList<T> lista)
        {
            PagedList<T> pagedList = new PagedList<T>();

            pagedList.PaginaActual = lista;

            pagedList.Estructura = new Estructura()
            {
                NumeroTotalElementos = 6,
                NumeroTotalPaginas = 2
            };

            return pagedList;
        }
    }
}
