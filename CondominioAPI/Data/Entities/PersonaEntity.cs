
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Data.Entities
{
    public class PersonaEntity
    {
        [Key]
        [Required]
        public long Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public long Identificacion { get; set; }
        public long Telefono { get; set; }
        public string Email { get; set; }
        public long Celular { get; set; }
        [ForeignKey("RolId")]
        public virtual RolEntity Rol { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
