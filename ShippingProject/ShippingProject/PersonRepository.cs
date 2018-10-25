using Shipping.EFCore.Domain;
using Shipping.EFCore.Domain.Models;
using Shipping.EFCore.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShippingProject.EFCore.Infra
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(ShippingDbContext context) : base(context)
        {

        }
        public PaginationResult<Person> RetrievePersonWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<Person> result = new PaginationResult<Person>();
            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Person>()
                .OrderBy(x => x.FirstName)
                .Skip(page)
                .Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Person>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Person>()
                .Where(x => x.FirstName.ToLower().Contains(filter.ToLower()) || x.LastName.ToLower().Contains(filter.ToLower()))
                .OrderBy(x => x.FirstName)
                .Skip(page).Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Person>().Where(x => x.FirstName.ToLower().Contains(filter.ToLower())).Count();
                }
            }
            return result;
        }
    }
}

