using Shipping.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipping.EFCore.Domain
{
    public interface ISupplierRepository
        : IRepository<Supplier>
    {
        PaginationResult<Supplier> RetrieveSupplierWithPagination(int page, int itemsPerPage, string filter);

    }
}
