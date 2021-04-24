using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data
{
    public class Person : DTO.Person
    {
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
