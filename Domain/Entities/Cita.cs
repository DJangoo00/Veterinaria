using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cita : BaseEntity
    {
        public int IdCitaFk {get; set;}
        public int IdMascotaFk {get; set;}
        public DateOnly Fecha {get; set;}
        public DateTime Hora {get; set;}
        public string Motivo {get; set;}
        public int IdVeterinarioFk {get; set;}

    }
}