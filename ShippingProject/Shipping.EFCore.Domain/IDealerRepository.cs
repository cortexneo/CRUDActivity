using Shipping.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipping.EFCore.Domain
{
    public interface IDealerRepository
        : IRepository<Dealer>
    {
        PaginationResult<Dealer> RetrieveDealerWithPagination(int page, int itemsPerPage, string filter);
    }
}
