using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Medicamento : BaseEntity
    {
        public string Nombre {get; set;}
        public int CantidadDisponible {get; set;}
        public int Precio {get; set;}
        public int IdLaboratorioFk {get; set;}
    }
}