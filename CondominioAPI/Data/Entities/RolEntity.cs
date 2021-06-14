using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Data.Entities
{
    public class RolEntity
    {
        [Key]
        [Required]
        public long Id { get; set; }
        public string NombreRol { get; set; }
        public ICollection<PersonaEntity> Personas { get; set; }
    }
}
