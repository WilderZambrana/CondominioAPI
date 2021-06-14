using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Data.Entities
{
    public class PublicacionEntity
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual UsuarioEntity Usuario { get; set; }
        [ForeignKey("DepartamentoId")]
        public virtual DepartamentoEntity Departamento { get; set; }
        public string Asunto { get; set; }
        public string Detalle { get; set; }
        public string Estado { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public long EnviadoA { get; set; }
    }
}
