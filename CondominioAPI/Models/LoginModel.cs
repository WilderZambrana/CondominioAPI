using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Models
{
    public class LoginModel
    {
        public long Id { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public long PersonaId { get; set; }
        public long RolId { get; set; }
    }
}
