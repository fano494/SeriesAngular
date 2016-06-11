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
        public static SerieDTO CargarSerieASerieDTO(Series serie)
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
            serieDTO.actores = (ICollection<ActorDTO>) serie.Actores;
            serieDTO.comentarios = (ICollection<ComentarioDTO>) serie.Comentarios;

            return serieDTO;
        }

        public static IList<SerieDTO> CargarSeriesASeriesDTO(IQueryable<Series> series)
        {
            IList<SerieDTO> seriesDTO = new List<SerieDTO>();

            foreach (Series serie in series)
            {
                seriesDTO.Add(CargarSerieASerieDTO(serie));
            }

            return seriesDTO;
        }
        public static void CargarSerieDTOASerie(SerieDTO serieDTO, Series serie)
        {
            serie.image = serieDTO.image;
            serie.gender = serieDTO.gender;
            serie.description = serieDTO.description;
            serie.director = serieDTO.director;
            serie.producer = serieDTO.producer;
            serie.year = serieDTO.year;
            serie.score = serieDTO.score;
            serie.seriename = serieDTO.seriename;
            serie.Actores = (ICollection<Actores>) serieDTO.actores;
            serie.Comentarios  = (ICollection<Comentarios>) serieDTO.comentarios;
        }
        
        public static void CargarSerieDTO_Usuario(Series serie, Usuarios usuario)
        {
            Usuario_Series us = new Usuario_Series();
            us.Usuarios = usuario;
            us.iduser = usuario.iduser;
            us.date = DateTime.Today;
            us.Series = serie;
            us.idserie = serie.idserie;

            usuario.Usuario_Series.Add(us);

        }
        
        public static void CargarUsuarioDTOAUsuario(UsuarioDTO usuarioDTO, Usuarios usuario)
        {
            usuario.country = usuarioDTO.country;
            usuario.email = usuarioDTO.email;
            usuario.password = usuarioDTO.password;
            usuario.profile = usuarioDTO.profile;
            usuario.username = usuarioDTO.username;
            usuario.Comentarios = (ICollection<Comentarios>) usuarioDTO.comentarios;
        }

        public static ICollection<SerieDTO> CargarUsuarioDTO_Series(Usuarios usuario)
        {
            IList<SerieDTO> seriesDTO = new List<SerieDTO>();

            foreach (Usuario_Series us in usuario.Usuario_Series)
            {
                seriesDTO.Add(CargarSerieASerieDTO(us.Series));
            }
            return seriesDTO;
        }

        public static UsuarioDTO CargarUsuarioAUsuarioDTO(Usuarios usuario)
        {
            UsuarioDTO usuarioDTO = new UsuarioDTO();

            usuarioDTO.admission = usuario.admission;
            usuarioDTO.country = usuario.country;
            usuarioDTO.email = usuario.email;
            usuarioDTO.iduser = usuario.iduser;
            usuarioDTO.password = usuario.password;
            usuarioDTO.profile = usuario.profile;
            usuarioDTO.username = usuario.username;
            usuarioDTO.series = CargarUsuarioDTO_Series(usuario);

            return usuarioDTO;
        }

        public static IList<UsuarioDTO> CargarUsuariosAUsuariosDTO(IQueryable<Usuarios> usuarios)
        {
            IList<UsuarioDTO> usuariosDTO = new List<UsuarioDTO>();

            foreach (Usuarios usuario in usuarios)
            {
                usuariosDTO.Add(CargarUsuarioAUsuarioDTO(usuario));
            }

            return usuariosDTO;
        }

    }
}
