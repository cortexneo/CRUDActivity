using Shipping.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.EFCore.Domain
{
    public interface IEmployeeRepository
        : IRepository<Employee>
    {
        //IEnumerable<Employee> GetEmployeeByDepartment(Guid departmentId);
    }
}
