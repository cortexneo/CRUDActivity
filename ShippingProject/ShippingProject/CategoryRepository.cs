using Shipping.EFCore.Infra;
using Shipping.EFCore.Domain;
using Shipping.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShippingProject.EFCore.Infra
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ShippingDbContext context) : base(context)
        {

        }

        public PaginationResult<Category> RetrieveCategoryWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<Category> result = new PaginationResult<Category>();
            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Category>()
                .OrderBy(x => x.CategoryName)
                .Skip(page)
                .Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Category>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Category>()
                .Where(x => x.CategoryName.ToLower().Contains(filter.ToLower()))
                .OrderBy(x => x.CategoryName)
                .Skip(page).Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Category>().Where(x => x.CategoryName.ToLower().Contains(filter.ToLower())).Count();
                }
            }
            return result;
        }
    }
}

