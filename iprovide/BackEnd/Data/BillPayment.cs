using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;

namespace BackEnd.Data
{
    public class BillPayment : DTO.BillPayment
    {
        public int TransactionId { get; set; }
        //public Transaction Transaction { get; set; }
    }
}
