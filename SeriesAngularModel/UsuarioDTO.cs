﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesAngularModel
{
    public class UsuarioDTO
    {
        public int iduser { get; set; }

        public string email { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public System.DateTime admission { get; set; }

        public string country { get; set; }

        public string profile { get; set; }
    }
}
