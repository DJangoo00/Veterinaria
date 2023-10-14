using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Raza : BaseEntity
    {
        public int IdEspecieFk {get; set;}
        public string Nombre {get; set;}
        
    }
}