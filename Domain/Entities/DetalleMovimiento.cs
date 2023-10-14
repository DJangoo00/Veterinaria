using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DetalleMovimiento : BaseEntity
    {
        public int IdProductoFk {get; set;}
        public int Cantidad {get; set;}
        public int IdMovMedFk {get; set;}
        public int Precio {get; set;}
    }
}