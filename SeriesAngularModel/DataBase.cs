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
        private List<SerieDTO> minibdSerie = new List<SerieDTO>();
        private List<UsuarioDTO> minibdUsuario = new List<UsuarioDTO>();

        public DataBase()
        {
            minibdSerie.Add(new SerieDTO(2, "Breaking Bad", "Serie de yonkis", "BHO", 2009, "Nose", "Accion" , "Angular/bbdd/img/bb.jpg", 8.5f));
            minibdSerie.Add(new SerieDTO(1, "Juego de tronos", "Serie de barcos y putas", "BHO", 2010, "Nose", "Drama", "Angular/bbdd/img/jdt.jpg", 8.8f));
            minibdUsuario.Add(new UsuarioDTO(1, "user@seriesangular.com", "user", "01/01/2016", "Un lugar llamado mundo"));
        }

        public SerieDTO ObtenerSerie(int id)
        {
            return minibdSerie.Find(i => i.Id == id);
        }
        public UsuarioDTO ObtenerUsuario(string email)
        {
            return minibdUsuario.Find(i => i.Email == email);
        }
        public PagedList<SerieDTO> ObtenerSeries(int start, int number, SerieFiltroDTO filtros)
        {
            return Utils.ToPagedList(minibdSerie);
        } 
    }
}
