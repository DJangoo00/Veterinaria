using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TratamientoMedico : BaseEntity
    {
        public int IdCitaFk {get; set;}
        public int IdMedicamentoFk {get; set;}
        public string Dosis {get; set;}
        public DateOnly FechaAdministracion {get; set;}
        public string Observacion {get; set;}
    }
}