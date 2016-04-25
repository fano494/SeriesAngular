using SeriesAngularModel;
using SeriesAngularModel.Filtros;
using SeriesAngularModel.PagedList;
using System.Collections.Generic;
using System.Web.Http;

namespace SeriesAngularWebAPI.Controllers
{
    public class SeriesController : ApiController
    {/*
        // POST: api/Serie
        [Route("api/Serie/{sort}/{reverse}/{start}/{number}")]
        public PagedList<SerieDTO> Post(string sort, bool reverse, int start, int number, [FromBody]SerieFiltroDTO filtros)
        {
            DataBase db = new DataBase();
            return db.ObtenerSeries(start, number, filtros);
        }

        // GET: api/Serie/5
        public SerieDTO Get(int id)
        {
            DataBase db = new DataBase();
            return db.ObtenerSerie(id);
        }

        // POST: api/Serie
        public int Post(SerieDTO serie)
        {
            DataBase db = new DataBase();
            return db.GuardarSerie(serie);
        }

        // DELETE: api/Serie/5
        public bool Delete(int id)
        {
            DataBase db = new DataBase();
            return db.BorrarSerie(id);
        }*/
    }
}
