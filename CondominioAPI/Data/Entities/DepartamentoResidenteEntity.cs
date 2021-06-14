using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Data.Entities
{
    public class DepartamentoResidenteEntity
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [ForeignKey("PersonaId")]
        public virtual PersonaEntity Persona { get; set; }
        [ForeignKey("DepartamentoId")]
        public virtual DepartamentoEntity Departamento { get; set; }
        public string EstadoPersona { get; set; }
    }
}
