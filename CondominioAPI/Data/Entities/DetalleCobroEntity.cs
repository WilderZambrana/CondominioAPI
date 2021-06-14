using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Data.Entities
{
    public class DetalleCobroEntity
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [ForeignKey("DepartamentoId")]
        public DepartamentoEntity Departmento { get; set; }
        [ForeignKey("TipoCobroId")]
        public TipoCobroEntity TipoCobro { get; set; }
        public int NumeroCuota { get; set; } //no se a que se refiere este atributo
        public string Estado { get; set; }
        public decimal ValorAPagar { get; set; }
        public decimal ValorPagado { get; set; }
        public DateTime FechaPago { get; set; }
        public DateTime FechaVence { get; set; }
        public double PorcentajeMulta { get; set; }
    }
}
