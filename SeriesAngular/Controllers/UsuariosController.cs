using SeriesAngularModel;
using SeriesAngularModel.Filtros;
using SeriesAngularModel.PagedList;
using System.Collections.Generic;
using System.Web.Http;
using SeriesAngularDAL;

namespace SeriesAngularWebAPI.Controllers
{
    public class UsuarioController : ApiController
    {
        [Route("api/Usuario/{sort}/{reverse}/{start}/{number}")]
        // POST: api/Usuario
        public PagedList<UsuarioDTO> Post(string sort, bool reverse, int start, int number, [FromBody]UsuarioFiltroDTO filtros)
        {
            DataBase db = new DataBase();
            return db.ObtenerUsuarios(start, number, filtros);
        }

        // GET: api/Usuario/Fano
        public UsuarioDTO Get(string id)
        {
            DataBase db = new DataBase();
            return db.ObtenerUsuario(id);
        }


        // POST: api/Usuario
        public int Post(UsuarioDTO usuario)
        {
            DataBase db = new DataBase();
            return db.GuardarUsuario(usuario);
        }

        // DELETE: api/Usuario/Fano
        public bool Delete(int id)
        {
            DataBase db = new DataBase();
            return db.BorrarUsuario(id);
        }
    }
}
