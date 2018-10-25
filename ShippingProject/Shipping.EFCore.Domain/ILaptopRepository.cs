using Shipping.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipping.EFCore.Domain
{
    public interface ILaptopRepository
        : IRepository<Laptop>
    {
        PaginationResult<Laptop> RetrieveLaptopWithPagination(int page, int itemsPerPage, string filter);
    }
}
