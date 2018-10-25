﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shipping.EFCore.Domain.Models
{
    [Table("Dealer")]
    public class Dealer
    {
        [Key]
        public Guid DealerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public bool? isActive { get; set; }

    }
}
