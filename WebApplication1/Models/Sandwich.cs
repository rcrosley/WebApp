using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Sandwich
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public decimal Price { get; set; }
        public string Rating { get; set; }
    }
}
