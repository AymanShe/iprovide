using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data
{
    public class Month : DTO.Month
    {
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
