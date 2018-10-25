using Shipping.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipping.EFCore.Domain
{
    public interface IPersonRepository
        : IRepository<Person>
    {
        PaginationResult<Person> RetrievePersonWithPagination(int page, int itemsPerPage, string filter);
    }
}
