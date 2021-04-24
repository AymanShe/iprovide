using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data
{
    public class Transaction : DTO.Transaction
    {
        public int PersonId { get; set; }
        //public Person Person { get; set; }
        public int CategoryId { get; set; }
        public TransactionCategory Category { get; set; }
        public Expense Expense { get; set; }
        public BillPayment Payment { get; set; }
    }
}
