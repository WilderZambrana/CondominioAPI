using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Data.Entities
{
    public class TipoCobroEntity
    {
        [Key]
        [Required]
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Valor { get; set; }
        public double MultaPorcentaje { get; set; }
        public int DiasEspera { get; set; }
    }
}
