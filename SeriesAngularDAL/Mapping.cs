using SeriesAngularModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesAngularDAL
{
    public class Mapping
    {
        public static SerieDTO CargarSerieASerieDTO(Serie serie)
        {
            SerieDTO serieDTO = new SerieDTO();

            serieDTO.idserie = serie.idserie;
            serieDTO.image = serie.image;
            serieDTO.gender = serie.gender;
            serieDTO.description = serie.description;
            serieDTO.director = serie.director;
            serieDTO.producer = serie.producer;
            serieDTO.year = serie.year;
            serieDTO.score = serie.score;
            serieDTO.seriename = serie.seriename;

            return serieDTO;
        }

        public static IList<SerieDTO> CargarSeriesASeriesDTO(IQueryable<Serie> series)
        {
            IList<SerieDTO> seriesDTO = new List<SerieDTO>();

            foreach (Serie serie in series)
            {
                seriesDTO.Add(CargarSerieASerieDTO(serie));
            }

            return seriesDTO;
        }
        public static void CargarSerieDTOASerie(SerieDTO serieDTO, Serie serie)
        {
            serie.image = serieDTO.image;
            serie.gender = serieDTO.gender;
            serie.description = serieDTO.description;
            serie.director = serieDTO.director;
            serie.producer = serieDTO.producer;
            serie.year = serieDTO.year;
            serie.score = serieDTO.score;
            serie.seriename = serieDTO.seriename;
        }
    }
}
