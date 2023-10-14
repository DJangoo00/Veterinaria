using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MovimientoMedicamento : BaseEntity
    {
        public int IdProductoFk {get; set;}
        public int Cantidad {get; set;}
        public DateOnly Fecha {get; set;}
    }
}