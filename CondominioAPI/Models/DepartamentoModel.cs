using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Models
{
    public class DepartamentoModel
    {
        public long Id { get; set; }
        public string Bloque { get; set; }
        public string NumeroDepartamento { get; set; }
        public int NumeroDormitorios { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public long PropietarioId { get; set; }
    }
}
