using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Data.Entities
{
    public class PropietarioEntity:PersonaEntity
    {
        public ICollection<DepartamentoEntity> Departamentos { get; set; }
    }
}
