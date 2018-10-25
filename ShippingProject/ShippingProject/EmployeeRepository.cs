using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Shipping.EFCore.Infra;
using Shipping.EFCore.Domain.Models;
using ShippingProject.EFCore.Infra;
using Shipping.EFCore.Domain;

namespace Shipping.EFCore.Infra
{
    public class EmployeeRepository
        : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ShippingDbContext context)
            : base(context)
        {

        }



    }
}
