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
            minibd.Add(new SerieDTO(1, "Breaking Bad", "Serie de yonkis"));
            minibd.Add(new SerieDTO(2, "Juego de tronos", "Serie de barcos y putas"));
        }

        public SerieDTO ObtenerSerie(int id)
        {
            return minibd.Find(i => i.Id == id);
        }
    }
}
