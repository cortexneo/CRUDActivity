using Shipping.EFCore.Domain;
using Shipping.EFCore.Domain.Models;
using Shipping.EFCore.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShippingProject.EFCore.Infra
{
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        public CarRepository(ShippingDbContext context) : base(context)
        {

        }
        public PaginationResult<Car> RetrieveCarWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<Car> result = new PaginationResult<Car>();
            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Car>()
                .OrderBy(x => x.CarName)
                .Skip(page)
                .Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Car>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Car>()
                .Where(x => x.CarName.ToLower().Contains(filter.ToLower()))
                .OrderBy(x => x.CarName)
                .Skip(page).Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Car>().Where(x => x.CarName.ToLower().Contains(filter.ToLower())).Count();
                }
            }
            return result;
        }
    }
}

