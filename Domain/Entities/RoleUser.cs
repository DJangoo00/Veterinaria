using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RoleUser : BaseEntity
    {
        public int IdUserFk {get; set;}
        public int IdRoleFk {get; set;}
    }
}