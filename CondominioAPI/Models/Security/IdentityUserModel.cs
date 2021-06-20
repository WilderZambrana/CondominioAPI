using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Models
{
    public class IdentityUserModel : IdentityUser
    {
        public long PersonaId { get; set; }
        public long RolId { get; set; }
    }
}
