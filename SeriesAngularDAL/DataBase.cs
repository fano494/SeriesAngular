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
        //----------------------------------
        //----- Series
        //----------------------------------

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

        //----------------------------------
        //----- Usuarios
        //----------------------------------

        public PagedList<UsuarioDTO> ObtenerUsuarios(int start, int number, UsuarioFiltroDTO filtros)
        {
            SeriesDBEntities se = new SeriesDBEntities();

#if DEBUG
            se.Database.Log = s => Console.WriteLine(s);
#endif

            var usuarios = se.Usuarios.Where(c => (string.IsNullOrEmpty(filtros.username) || c.username.ToLower().Contains(filtros.username.ToLower())))
                                  .OrderBy(c => c.username).Skip(start).Take(number);

            return Utils.ToPagedList(Mapping.CargarUsuariosAUsuariosDTO(usuarios));
        }

        public UsuarioDTO ObtenerUsuario(string id)
        {
            SeriesDBEntities se = new SeriesDBEntities();

#if DEBUG
            se.Database.Log = s => Console.WriteLine(s);
#endif

            var usuario = se.Usuarios.SingleOrDefault(c => c.username == id);

            return Mapping.CargarUsuarioAUsuarioDTO(usuario);
        }

        public int GuardarUsuario(UsuarioDTO usuarioDTO)
        {
            SeriesDBEntities se = new SeriesDBEntities();

#if DEBUG
            se.Database.Log = s => Console.WriteLine(s);
#endif
            Usuario usuario;

            if (usuarioDTO.iduser.HasValue)
            {
                usuario = se.Usuarios.SingleOrDefault(c => c.iduser == usuarioDTO.iduser);
            }
            else
            {
                usuario = new Usuario();
                se.Usuarios.Add(usuario);
            }

            Mapping.CargarUsuarioDTOAUsuario(usuarioDTO, usuario);

            se.SaveChanges();

            return usuario.iduser;
        }

        public bool BorrarUsuario(int id)
        {
            SeriesDBEntities se = new SeriesDBEntities();

#if DEBUG
            se.Database.Log = s => Console.WriteLine(s);
#endif

            se.Usuarios.Remove(se.Usuarios.SingleOrDefault(c => c.iduser == id));

            se.SaveChanges();

            return true;
        }

        public bool SeguirSerie(int idserie, int iduser)
        {
            SeriesDBEntities se = new SeriesDBEntities();

#if DEBUG
            se.Database.Log = s => Console.WriteLine(s);
#endif
            Serie serie = se.Series.SingleOrDefault(c => c.idserie == idserie);
            Usuario usuario =  se.Usuarios.SingleOrDefault(c => c.iduser == iduser);
            Mapping.CargarSerieDTO_Usuario(serie, usuario);

            return true;
        }
    }
}
