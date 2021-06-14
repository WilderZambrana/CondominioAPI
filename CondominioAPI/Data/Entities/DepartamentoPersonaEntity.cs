﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Data.Entities
{
    public class DepartamentoPersonaEntity
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [ForeignKey("ResidenteId")]
        public ResidenteEntity Residente { get; set; }
        [ForeignKey("DepartamentoId")]
        public DepartamentoEntity Departamento { get; set; }
        public string EstadoPersona { get; set; }
    }
}
