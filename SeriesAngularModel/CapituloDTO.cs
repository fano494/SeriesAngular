using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesAngularModel
{
    class CapituloDTO
    {
        public int idseason { get; set; }

        public int nchapter { get; set; }

        public Nullable<decimal> score { get; set; }

        public string description { get; set; }

        public int idchapter { get; set; }
    }
}
