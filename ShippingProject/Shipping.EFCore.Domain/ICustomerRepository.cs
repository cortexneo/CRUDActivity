using Shipping.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipping.EFCore.Domain
{
    public interface ICustomerRepository
        : IRepository<Customer>
    {
    }
}
