using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data
{
    public class Bill : DTO.Bill
    {
        public Person Owner { get; set; }
        public int CategoryId { get; set; }
        public BillCategory Category { get; set; }
        public virtual ICollection<BillPayment> BillPayments { get; set; }
    }
}
