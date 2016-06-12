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
            
            var serieDTO = Mapping.CargarSerieASerieDTO(serie);
            serieDTO.temporadas = Mapping.CargarTemporadasATemporadasDTO(serie.Temporadas);
            foreach(TemporadaDTO temporadaDTO in serieDTO.temporadas)
            {
                var tmp = serie.Temporadas.SingleOrDefault(c => c.idseanson == temporadaDTO.idseanson);
                temporadaDTO.capitulos = Mapping.CargarCapitulosACapitulosDTO(tmp.Capitulos.AsQueryable());
            }
            return serieDTO;
        }

        public int GuardarSerie(SerieDTO serieDTO)
        {
            SeriesDBEntities se = new SeriesDBEntities();

#if DEBUG
            se.Database.Log = s => Console.WriteLine(s);
#endif
            Series serie;

            if (serieDTO.idserie.HasValue)
            {
                serie = se.Series.SingleOrDefault(c => c.idserie == serieDTO.idserie);
            }
            else
            {
                serie = new Series();
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
            var serie = se.Series.SingleOrDefault(c => c.idserie == id);
            foreach (Temporadas temporada in serie.Temporadas)
            {
                BorrarTemporada(temporada.idseanson);
            }
            se.Series.Remove(serie);

            se.SaveChanges();

            return true;
        }

        //----------------------------------
        //----- Temporada
        //----------------------------------

        public int GuardarTemporada(TemporadaDTO temporadaDTO)
        {
            SeriesDBEntities se = new SeriesDBEntities();

#if DEBUG
            se.Database.Log = s => Console.WriteLine(s);
#endif
            Temporadas temporada;

            if (temporadaDTO.idseanson.HasValue)
            {
                temporada = se.Temporadas.SingleOrDefault(c => c.idseanson == temporadaDTO.idseanson);
            }
            else
            {
                temporada = new Temporadas();
                se.Temporadas.Add(temporada);
            }

            Mapping.CargarTemporadaDTOATemporada(temporadaDTO, temporada);
            foreach(CapituloDTO capitulo in temporadaDTO.capitulos)
            {
                temporada.Capitulos.Add(GuardarCapitulo(capitulo));
            }

            se.SaveChanges();

            return temporada.idseanson;
        }

        public bool BorrarTemporada(int id)
        {
            SeriesDBEntities se = new SeriesDBEntities();

#if DEBUG
            se.Database.Log = s => Console.WriteLine(s);
#endif
            var temporada = se.Temporadas.SingleOrDefault(c => c.idseanson == id);
            foreach (Capitulos capitulo in temporada.Capitulos)
            {
                BorrarCapitulo(capitulo.idchapter);
            }
            se.Temporadas.Remove(temporada);

            se.SaveChanges();

            return true;
        }

        //----------------------------------
        //----- Capitulos
        //----------------------------------

        public Capitulos GuardarCapitulo(CapituloDTO capituloDTO)
        {
            SeriesDBEntities se = new SeriesDBEntities();

#if DEBUG
            se.Database.Log = s => Console.WriteLine(s);
#endif
            Capitulos capitulo;

            if (capituloDTO.idchapter.HasValue)
            {
                capitulo = se.Capitulos.SingleOrDefault(c => c.idchapter == capituloDTO.idchapter);
            }
            else
            {
                capitulo = new Capitulos();
                se.Capitulos.Add(capitulo);
            }

            Mapping.CargarCapituloDTOACapitulo(capituloDTO, capitulo);

            se.SaveChanges();

            return capitulo;
        }

        public bool BorrarCapitulo(int id)
        {
            SeriesDBEntities se = new SeriesDBEntities();

#if DEBUG
            se.Database.Log = s => Console.WriteLine(s);
#endif

            se.Capitulos.Remove(se.Capitulos.SingleOrDefault(c => c.idchapter == id));

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


            se.Database.Log = s => Console.WriteLine(s);


            var usuario = se.Usuarios.SingleOrDefault(c => c.username == id);

            if (usuario == null)
            {
                return new UsuarioDTO();
            }
            else
            {
                return Mapping.CargarUsuarioAUsuarioDTO(usuario);
            }
        }

        public int GuardarUsuario(UsuarioDTO usuarioDTO)
        {
            SeriesDBEntities se = new SeriesDBEntities();

#if DEBUG
            se.Database.Log = s => Console.WriteLine(s);
#endif
            Usuarios usuario;

            if (usuarioDTO.iduser.HasValue)
            {
                usuario = se.Usuarios.SingleOrDefault(c => c.iduser == usuarioDTO.iduser);
            }
            else
            {
                usuario = new Usuarios();
                usuario.admission = DateTime.Today;
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
            Series serie = se.Series.SingleOrDefault(c => c.idserie == idserie);
            Usuarios usuario =  se.Usuarios.SingleOrDefault(c => c.iduser == iduser);
            se.Usuario_Series.Add(Mapping.CargarSerie_Usuario(serie, usuario));

            se.SaveChanges();

            return true;
        }

        public bool DejarSerie(int idserie, int iduser)
        {
            SeriesDBEntities se = new SeriesDBEntities();

#if DEBUG
            se.Database.Log = s => Console.WriteLine(s);
#endif
            se.Usuario_Series.Remove(se.Usuario_Series.SingleOrDefault(c => (c.iduser == iduser) && (c.idserie == idserie)));

            se.SaveChanges();

            return true;
        }

        //----------------------------------
        //----- Comentarios
        //----------------------------------
        public int GuardarComentario(ComentarioDTO comentarioDTO)
        {
            SeriesDBEntities se = new SeriesDBEntities();

#if DEBUG
            se.Database.Log = s => Console.WriteLine(s);
#endif
            Comentarios comentario;

            if (comentarioDTO.idcomment.HasValue)
            {
                comentario = se.Comentarios.SingleOrDefault(c => c.idcomment == comentarioDTO.idcomment);
            }
            else
            {
                comentario = new Comentarios();
                Series serie = se.Series.SingleOrDefault(c => c.idserie == comentario.idserie);
                Usuarios usuario = se.Usuarios.SingleOrDefault(c => c.iduser == comentario.iduser);
                comentario.Series = serie;
                comentario.Usuarios = usuario;
                comentario.commentdate = DateTime.Today;
                se.Comentarios.Add(comentario);
            }

            Mapping.CargarComentarioDTOAComentario(comentarioDTO, comentario);
            

            se.SaveChanges();

            return comentario.idcomment;
        }

        public bool BorrarComentario(int idcomment)
        {
            SeriesDBEntities se = new SeriesDBEntities();

#if DEBUG
            se.Database.Log = s => Console.WriteLine(s);
#endif
            se.Comentarios.Remove(se.Comentarios.SingleOrDefault(c => c.idcomment == idcomment));

            se.SaveChanges();

            return true;
        }

        //----------------------------------
        //----- Actores
        //----------------------------------

        public bool AsignarActor(int idserie, int idactor)
        {
            SeriesDBEntities se = new SeriesDBEntities();

#if DEBUG
            se.Database.Log = s => Console.WriteLine(s);
#endif
            Series serie = se.Series.SingleOrDefault(c => c.idserie == idserie);
            Actores actor = se.Actores.SingleOrDefault(c => c.idactor == idactor);
            serie.Actores.Add(actor);

            se.SaveChanges();

            return true;
        }

        public bool QuitarActor(int idserie, int idactor)
        {
            SeriesDBEntities se = new SeriesDBEntities();

#if DEBUG
            se.Database.Log = s => Console.WriteLine(s);
#endif
            Series serie = se.Series.SingleOrDefault(c => c.idserie == idserie);
            serie.Actores.Remove(serie.Actores.SingleOrDefault(c => c.idactor == idactor));

            se.SaveChanges();

            return true;
        }

    }
}
