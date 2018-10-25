using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shipping.EFCore.Domain.Models
{
    [Table("Responsibility")]
    public class Responsibility
    {
        [Key]
        public Guid ResponsibilityID { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool isActive { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
    }
}
