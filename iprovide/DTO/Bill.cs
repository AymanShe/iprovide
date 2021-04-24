using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Bill
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime? DateIssued { get; set; }
        public DateTime? DateFullyPaid { get; set; }
        public bool IsShared { get; set; }
        public double Balance { get; set; }
    }
}
