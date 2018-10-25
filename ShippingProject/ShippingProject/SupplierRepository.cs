using Shipping.EFCore.Domain;
using Shipping.EFCore.Domain.Models;
using Shipping.EFCore.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShippingProject.EFCore.Infra
{
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ShippingDbContext context) : base(context)
        {

        }
        public PaginationResult<Supplier> RetrieveSupplierWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<Supplier> result = new PaginationResult<Supplier>();
            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Supplier>()
                .OrderBy(x => x.CompanyName)
                .Skip(page)
                .Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Supplier>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Supplier>()
                .Where(x => x.CompanyName.ToLower().Contains(filter.ToLower()))
                .OrderBy(x => x.CompanyName)
                .Skip(page).Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Supplier>().Where(x => x.CompanyName.ToLower().Contains(filter.ToLower())).Count();
                }
            }
            return result;
        }
    }
}

