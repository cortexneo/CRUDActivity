using Shipping.EFCore.Domain;
using Shipping.EFCore.Domain.Models;
using Shipping.EFCore.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShippingProject.EFCore.Infra
{
    public class LaptopRepository : RepositoryBase<Laptop>, ILaptopRepository
    {
        public LaptopRepository(ShippingDbContext context) : base(context)
        {

        }
        public PaginationResult<Laptop> RetrieveLaptopWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<Laptop> result = new PaginationResult<Laptop>();
            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Laptop>()
                .OrderBy(x => x.LaptopName)
                .Skip(page)
                .Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Laptop>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Laptop>()
                .Where(x => x.LaptopName.ToLower().Contains(filter.ToLower()))
                .OrderBy(x => x.LaptopName)
                .Skip(page).Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Laptop>().Where(x => x.LaptopName.ToLower().Contains(filter.ToLower())).Count();
                }
            }
            return result;
        }
    }
}

