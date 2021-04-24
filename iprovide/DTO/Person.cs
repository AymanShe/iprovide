using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DTO
{
    public class Person
    {
        public int Id { get; set; }
        /// <summary>
        /// The name of the person
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public double CurrentDebtBalance { get; set; }
        public double CurrentBillBalance { get; set; }
    }
}
