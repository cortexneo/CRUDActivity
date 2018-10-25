using Shipping.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipping.EFCore.Domain
{
    public interface IResponsibilityRepository
        : IRepository<Responsibility>
    {
        PaginationResult<Responsibility> RetrieveResponsibilityWithPagination(int page, int itemsPerPage, string filter);
    }
}
