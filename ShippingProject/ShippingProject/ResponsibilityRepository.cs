using Shipping.EFCore.Infra;
using Shipping.EFCore.Domain;
using Shipping.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShippingProject.EFCore.Infra
{
    public class ResponsibilityRepository : RepositoryBase<Responsibility>, IResponsibilityRepository
    {
        public ResponsibilityRepository(ShippingDbContext context) : base(context)
        {

        }

        public PaginationResult<Responsibility> RetrieveResponsibilityWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<Responsibility> result = new PaginationResult<Responsibility>();
            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Responsibility>()
                .OrderBy(x => x.Description)
                .Skip(page)
                .Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Responsibility>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Responsibility>()
                .Where(x => x.Description.ToLower().Contains(filter.ToLower()))
                .OrderBy(x => x.Description)
                .Skip(page).Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Responsibility>().Where(x => x.Description.ToLower().Contains(filter.ToLower())).Count();
                }
            }
            return result;
        }
    }
}

