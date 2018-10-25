using Shipping.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipping.EFCore.Domain
{
    public interface ICarRepository
        : IRepository<Car>
    {
        PaginationResult<Car> RetrieveCarWithPagination(int page, int itemsPerPage, string filter);
    }
}
