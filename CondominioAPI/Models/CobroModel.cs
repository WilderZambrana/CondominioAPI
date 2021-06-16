using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Models
{
    public class CobroModel
    {
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public float Valor { get; set; }
        public double MultaPorcentaje { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public long DepartamentoId { get; set; }
    }
}
