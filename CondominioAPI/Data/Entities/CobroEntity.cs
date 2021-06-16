using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Data.Entities
{
    public class CobroEntity
    {
        [Key]
        [Required]
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public decimal? Valor { get; set; }
        public double? MultaPorcentaje { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        [ForeignKey("DepartamentoId")]
        public virtual DepartamentoEntity Departamento { get; set; }
    }
}
