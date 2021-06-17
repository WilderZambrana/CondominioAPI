using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Models
{
    public class PublicacionModel
    {
        public long Id { get; set; }
        public long PersonaId { get; set; }
        public string Asunto { get; set; }
        public string Detalle { get; set; }
        public DateTime? FechaPublicacion { get; set; }
    }
}
