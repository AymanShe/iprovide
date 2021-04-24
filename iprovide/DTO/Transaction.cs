using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
    public class Transaction
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public double PayerDebtBalance { get; set; }
        public double PayerBillsBalance { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Date { get; set; }
    }
}
