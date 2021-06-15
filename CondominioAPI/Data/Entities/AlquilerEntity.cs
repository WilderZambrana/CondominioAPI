using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Data.Entities
{
    public class AlquilerEntity
    {
        [Key]
        [Required]
        public long Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        [ForeignKey("DepartamentoId")]
        public virtual DepartamentoEntity Departamento { get; set; }
        [ForeignKey("ArrendatarioId")]
        public virtual PersonaEntity Arrendatario { get; set; }
    }
}
