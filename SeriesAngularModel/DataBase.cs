using SeriesAngularModel.Filtros;
using SeriesAngularModel.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesAngularModel
{
    public class DataBase
    {
        private List<SerieDTO> minibd = new List<SerieDTO>();

        public DataBase()
        {
            minibd.Add(new SerieDTO(2, "Breaking Bad", "Serie de yonkis", "Angular/bbdd/img/bb.jpg", 8.5f));
            minibd.Add(new SerieDTO(1, "Juego de tronos", "Serie de barcos y putas", "Angular/bbdd/img/jdt.jpg", 8.8f));
        }

        public SerieDTO ObtenerSerie(int id)
        {
            return minibd.Find(i => i.Id == id);
        }

        public PagedList<SerieDTO> ObtenerSeries(int start, int number, SerieFiltroDTO filtros)
        {
            return Utils.ToPagedList(minibd);
        }
    }
}
