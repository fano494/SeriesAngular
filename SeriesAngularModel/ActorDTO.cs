using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesAngularModel
{
    class ActorDTO
    {
        public int idactor { get; set; }

        public string actorname { get; set; }

        public Nullable<System.DateTime> birthdate { get; set; }

        public Nullable<decimal> score { get; set; }

        public string country { get; set; }

        public string photo { get; set; }
    }
}
