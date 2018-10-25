using Shipping.EFCore.Domain;
using Shipping.EFCore.Domain.Models;
using Shipping.EFCore.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShippingProject.EFCore.Infra
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ShippingDbContext context) : base(context)
        {

        }
        public PaginationResult<Product> RetrieveProductWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<Product> result = new PaginationResult<Product>();
            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Product>()
                .OrderBy(x => x.ProductName)
                .Skip(page)
                .Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Product>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Product>()
                .Where(x => x.ProductName.ToLower().Contains(filter.ToLower()))
                .OrderBy(x => x.ProductName)
                .Skip(page).Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Product>().Where(x => x.ProductName.ToLower().Contains(filter.ToLower())).Count();
                }
            }
            return result;
        }
    }
}

