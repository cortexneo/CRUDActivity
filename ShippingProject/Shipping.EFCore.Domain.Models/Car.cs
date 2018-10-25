using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shipping.EFCore.Domain.Models
{
    [Table("Car")]
    public class Car
    {
        [Key]
        public Guid CarID { get; set; }
        public string CarName { get; set; }
        public string CarColor { get; set; }
        public string CarFuel { get; set; }
        public String YearModel { get; set; }
        public string Transmission { get; set; }
        public string CarType { get; set; }
        public string CarManufacturer { get; set; }
        public bool? inStock { get; set; }

    }
}
