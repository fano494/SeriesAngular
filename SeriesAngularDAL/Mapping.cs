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
            serieDTO.actores = CargarActoresAActoresDTO(serie.Actores);
            serieDTO.comentarios = CargarComentariosAComentariosDTO(serie.Comentarios);
            serieDTO.temporadas = CargarTemporadasATemporadasDTO(serie.Temporadas);

            return serieDTO;
        }

        public static CapituloDTO CargarCapituloACapituloDTO(Capitulos capitulo)
        {
            CapituloDTO capituloDTO = new CapituloDTO();

            capituloDTO.description = capitulo.description;
            capituloDTO.idchapter = capitulo.idchapter;
            capituloDTO.idseason = capitulo.idseason;
            capituloDTO.nchapter = capitulo.nchapter;
            capituloDTO.score = capitulo.score;

            return capituloDTO;
        } 

        public static void CargarCapituloDTOACapitulo(CapituloDTO capituloDTO, Capitulos capitulo)
        {
            capitulo.description = capituloDTO.description;
            capitulo.idseason = capituloDTO.idseason;
            capitulo.nchapter = capituloDTO.nchapter;
            capitulo.score = capituloDTO.score;
        }

        public static IList<CapituloDTO> CargarCapitulosACapitulosDTO(IQueryable<Capitulos> capitulos)
        {
            IList<CapituloDTO> capitulosDTO = new List<CapituloDTO>();

            foreach (Capitulos capitulo in capitulos)
            {
                capitulosDTO.Add(CargarCapituloACapituloDTO(capitulo));
            }

            return capitulosDTO;
        }

        public static TemporadaDTO CargarTemporadaATemporadaDTO(Temporadas temporada)
        {
            TemporadaDTO temporadaDTO = new TemporadaDTO();

            temporadaDTO.chapters = temporada.chapters;
            temporadaDTO.idseanson = temporada.idseanson;
            temporadaDTO.idserie = temporada.idserie;
            temporadaDTO.nseason = temporada.nseason;
            temporadaDTO.year = temporada.year;

            return temporadaDTO;
        }

        public static void CargarTemporadaDTOATemporada(TemporadaDTO temporadaDTO, Temporadas temporada)
        {
            temporada.chapters = temporadaDTO.chapters;
            temporada.idserie = temporadaDTO.idserie;
            temporada.nseason = temporadaDTO.nseason;
            temporada.year = temporadaDTO.year;
        }

        public static IList<TemporadaDTO> CargarTemporadasATemporadasDTO(ICollection<Temporadas> temporadas)
        {
            IList<TemporadaDTO> temporadasDTO = new List<TemporadaDTO>();

            foreach (Temporadas temporada in temporadas)
            {
                temporadasDTO.Add(CargarTemporadaATemporadaDTO(temporada));
            }

            return temporadasDTO;
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
        }
        
        public static Usuario_Series CargarSerie_Usuario(Series serie, Usuarios usuario)
        {
            Usuario_Series us = new Usuario_Series();
            us.Usuarios = usuario;
            us.iduser = usuario.iduser;
            us.date = DateTime.Today;
            us.Series = serie;
            us.idserie = serie.idserie;

            return us;

        }
        
        public static void CargarUsuarioDTOAUsuario(UsuarioDTO usuarioDTO, Usuarios usuario)
        {
            usuario.country = usuarioDTO.country;
            usuario.email = usuarioDTO.email;
            usuario.password = usuarioDTO.password;
            usuario.profile = usuarioDTO.profile;
            usuario.username = usuarioDTO.username;
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

        public static ComentarioDTO CargarComentarioAComentarioDTO(Comentarios comentario)
        {
            ComentarioDTO comentarioDTO = new ComentarioDTO();

            comentarioDTO.comment = comentario.comment;
            comentarioDTO.commentdate = comentario.commentdate;
            comentarioDTO.idcomment = comentario.idcomment;
            comentarioDTO.idserie = comentario.idserie;
            comentarioDTO.iduser = comentario.iduser;

            return comentarioDTO;
        }

        public static IList<ComentarioDTO> CargarComentariosAComentariosDTO(ICollection<Comentarios> comentarios)
        {
            IList<ComentarioDTO> comentariosDTO = new List<ComentarioDTO>();

            foreach (Comentarios comentario in comentarios)
            {
                comentariosDTO.Add(CargarComentarioAComentarioDTO(comentario));
            }

            return comentariosDTO;
        }

        public static void CargarComentarioDTOAComentario(ComentarioDTO comentarioDTO, Comentarios comentario)
        {
            comentario.comment = comentarioDTO.comment;
            comentario.idserie = comentarioDTO.idserie;
            comentario.iduser = comentarioDTO.iduser;
        }

        public static ActorDTO CargarActorAActorDTO(Actores actor)
        {
            ActorDTO actorDTO = new ActorDTO();

            actorDTO.actorname = actor.actorname;
            actorDTO.birthdate = actor.birthdate;
            actorDTO.country = actor.country;
            actorDTO.idactor = actor.idactor;
            actorDTO.photo = actor.photo;
            actorDTO.score = actor.score;


            return actorDTO;
        }

        public static IList<ActorDTO> CargarActoresAActoresDTO(ICollection<Actores> actores)
        {
            IList<ActorDTO> actoresDTO = new List<ActorDTO>();

            foreach (Actores actor in actores)
            {
                actoresDTO.Add(CargarActorAActorDTO(actor));
            }

            return actoresDTO;
        }

        public static Actores CargarActorDTOAActor(ActorDTO actorDTO)
        {
            Actores actor = new Actores();
            actor.actorname = actorDTO.actorname;
            actor.birthdate = actorDTO.birthdate;
            actor.country = actorDTO.country;
            actor.idactor = actorDTO.idactor;
            actor.photo = actorDTO.photo;
            actor.score = actorDTO.score;
            actor.idactor = actorDTO.idactor;
            return actor;
        }
    }
}
