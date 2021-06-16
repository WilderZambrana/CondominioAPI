using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Data.Entities
{
    public class PublicacionEntity
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [ForeignKey("PersonaId")]
        public virtual PersonaEntity Persona { get; set; }
        public string Asunto { get; set; }
        public string Detalle { get; set; }
        public DateTime? FechaPublicacion { get; set; }
    }
}
