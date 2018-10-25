using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shipping.EFCore.Domain.Models
{
    [Table("Laptop")]
    public class Laptop
    {
        [Key]
        public Guid LaptopID { get; set; }
        [Required]
        public string LaptopName { get; set; }
        public int Quantity { get; set; }
    }
}
