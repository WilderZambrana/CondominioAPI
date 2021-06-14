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
        public string Bloque { get; set; } // este atributo se puede modificar por un foreignkey creando el entity bloque
        public string NumeroDepartamento { get; set; } // ejemplo: 1A 
        public int NumeroDormitorios { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
