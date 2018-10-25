using Shipping.EFCore.Infra;
using Shipping.EFCore.Domain;
using Shipping.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShippingProject.EFCore.Infra
{
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(ShippingDbContext context): base(context)
        {

        }

        public OrderDetail GetOrderDetailsWithForeignKey(Guid id)
        {
            OrderDetail result = new OrderDetail();
            result = context.Set<OrderDetail>().Where(x => x.OrderID == id).FirstOrDefault();
            return result;
        }
    }
}
    
