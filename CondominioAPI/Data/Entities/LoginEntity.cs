using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Data.Entities
{
    public class LoginEntity
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [ForeignKey("ResidenteId")]
        public virtual ResidenteEntity Residente { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        [ForeignKey("RolId")]
        public virtual RolEntity Rol { get; set; }
        public string Estado { get; set; }
    }
}
