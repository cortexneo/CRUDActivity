using Shipping.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipping.EFCore.Domain
{
    public interface ICategoryRepository
        : IRepository<Category>
    {
        PaginationResult<Category> RetrieveCategoryWithPagination(int page, int itemsPerPage, string filter);
    }
}
