using SeriesAngularModel;
using SeriesAngularModel.Filtros;
using SeriesAngularModel.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesAngularDAL
{
    public class DataBase
    {
        public PagedList<SerieDTO> ObtenerSeries(int start, int number, SerieFiltroDTO filtros)
        {
            SeriesDBEntities se = new SeriesDBEntities();

#if DEBUG
            se.Database.Log = s => Console.WriteLine(s);
#endif

            var series = se.Series.Where(c => (string.IsNullOrEmpty(filtros.seriename) || c.seriename.ToLower().Contains(filtros.seriename.ToLower())))
                                  .OrderBy(c => c.score).Skip(start).Take(number);

            return Utils.ToPagedList(Mapping.CargarSeriesASeriesDTO(series));
        }

        public SerieDTO ObtenerSerie(int id)
        {
            SeriesDBEntities se = new SeriesDBEntities();

#if DEBUG
            se.Database.Log = s => Console.WriteLine(s);
#endif

            var serie = se.Series.SingleOrDefault(c => c.idserie == id);

            return Mapping.CargarSerieASerieDTO(serie);
        }

        public int GuardarSerie(SerieDTO serieDTO)
        {
            SeriesDBEntities se = new SeriesDBEntities();

#if DEBUG
            se.Database.Log = s => Console.WriteLine(s);
#endif
            Serie serie;

            if (serieDTO.idserie.HasValue)
            {
                serie = se.Series.SingleOrDefault(c => c.idserie == serieDTO.idserie);
            }
            else
            {
                serie = new Serie();
                se.Series.Add(serie);
            }

            Mapping.CargarSerieDTOASerie(serieDTO, serie);

            se.SaveChanges();

            return serie.idserie;
        }

        public bool BorrarSerie(int id)
        {
            SeriesDBEntities se = new SeriesDBEntities();

#if DEBUG
            se.Database.Log = s => Console.WriteLine(s);
#endif

            se.Series.Remove(se.Series.SingleOrDefault(c => c.idserie == id));

            se.SaveChanges();

            return true;
        }
    }
}
