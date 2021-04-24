using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PersonResponse : Person
    {
        public double CurrentDebtBalance { get; set; }
    }
}
