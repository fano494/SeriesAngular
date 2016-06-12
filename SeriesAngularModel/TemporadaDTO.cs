using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesAngularModel
{
    public class TemporadaDTO
    {
        public int idserie { get; set; }

        public int nseason { get; set; }

        public Nullable<int> chapters { get; set; }

        public Nullable<int> year { get; set; }

        public Nullable<int> idseanson { get; set; }

        public ICollection<CapituloDTO> capitulos { get; set; }
    }
}
