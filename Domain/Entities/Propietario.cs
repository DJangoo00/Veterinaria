using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Propietario : BaseEntity
    {
        public string Nombre {get; set;}
        public string CorreoElectronico {get; set;}
        public string Telefono {get; set;}
    }
}