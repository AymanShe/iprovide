using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class TransactionResponse : Transaction
    {
        public int PersonId { get; set; }
        //public Person Person { get; set; }
        public int CategoryId { get; set; }
        public TransactionCategory Category { get; set; }
        public Expense Expense { get; set; }
        public BillPayment Payment { get; set; }
    }
}
