using Shipping.EFCore.Infra;
using Shipping.EFCore.Domain;
using Shipping.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShippingProject.EFCore.Infra
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(ShippingDbContext context) : base(context)
        {

        }
    }
}

