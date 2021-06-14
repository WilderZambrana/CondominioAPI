using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Data.Entities
{
    public class DepartamentoEntity
    {
        [Key]
        [Required]
        public long Id { get; set; }
        public string Bloque { get; set; }
        public string NumeroDepartamento { get; set; } // ejemplo: 1A 
        public int NumeroDormitorios { get; set; }        
        public DateTime FechaRegistro { get; set; }
        [ForeignKey("PropietarioId")]
        public virtual PropietarioEntity Propietario { get; set; }
        [ForeignKey("ArrendatarioId")]
        public virtual ArrendatarioEntity Arrendatario { get; set; }
        public DateTime FechaActualizacion { get; set; }        
    }
}
