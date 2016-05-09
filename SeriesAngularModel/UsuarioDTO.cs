using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesAngularModel
{
    public class UsuarioDTO
    {
        public Nullable<int> Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Admission { get; set; }

        public string Country { get; set; }

        public UsuarioDTO(int id, string email, string password, string admission, string country)
        {
            Id = id;
            Email = email;
            Password = password;
            Admission = admission;
            Country = country;
        }
    }
}
