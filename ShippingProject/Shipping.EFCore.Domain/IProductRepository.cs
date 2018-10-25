using Shipping.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipping.EFCore.Domain
{
    public interface IProductRepository
        : IRepository<Product>
    {
        PaginationResult<Product> RetrieveProductWithPagination(int page, int itemsPerPage, string filter);
    }
}
