using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesAngularModel
{
    public class ComentarioDTO
    {
        public Nullable<int> idcomment { get; set; }

        public int iduser { get; set; }

        public int idserie { get; set; }

        public string comment { get; set; }

        public Nullable<System.DateTime> commentdate { get; set; }
    }
}
