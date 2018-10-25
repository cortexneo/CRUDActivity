using Shipping.EFCore.Domain;
using Shipping.EFCore.Domain.Models;
using Shipping.EFCore.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShippingProject.EFCore.Infra
{
    public class ShipperRepository : RepositoryBase<Shipper>, IShipperRepository
    {
        public ShipperRepository(ShippingDbContext context) : base(context)
        {

        }
        public PaginationResult<Shipper> RetrieveShipperWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<Shipper> result = new PaginationResult<Shipper>();
            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Shipper>()
                .OrderBy(x => x.CompanyName)
                .Skip(page)
                .Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Shipper>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Shipper>()
                .Where(x => x.CompanyName.ToLower().Contains(filter.ToLower()))
                .OrderBy(x => x.CompanyName)
                .Skip(page).Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Shipper>().Where(x => x.CompanyName.ToLower().Contains(filter.ToLower())).Count();
                }
            }
            return result;
        }
    }
}

