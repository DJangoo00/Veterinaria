using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Mascota : BaseEntity
    {
        public int IdPropietarioFk {get; set;}
        public int IdEpecieFk {get; set;}
        public int IRazaFk {get; set;}
        public string Nombre {get; set;}
        public DateTime FechaNacimiento {get; set;}
    }
}