using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Models
{
    public class AlquilerModel
    {
        public long Id { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public long DepartamentoId { get; set; }
        public long ArrendatarioId { get; set; }
    }
}
