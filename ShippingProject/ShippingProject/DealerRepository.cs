using Shipping.EFCore.Domain;
using Shipping.EFCore.Domain.Models;
using Shipping.EFCore.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShippingProject.EFCore.Infra
{
    public class DealerRepository : RepositoryBase<Dealer>, IDealerRepository
    {
        public DealerRepository(ShippingDbContext context) : base(context)
        {

        }
        public PaginationResult<Dealer> RetrieveDealerWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<Dealer> result = new PaginationResult<Dealer>();
            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Dealer>()
                .OrderBy(x => x.FirstName)
                .Skip(page)
                .Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Dealer>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Dealer>()
                .Where(x => x.FirstName.ToLower().Contains(filter.ToLower()))
                .OrderBy(x => x.FirstName)
                .Skip(page).Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Dealer>().Where(x => x.FirstName.ToLower().Contains(filter.ToLower())).Count();
                }
            }
            return result;
        }
    }
}

