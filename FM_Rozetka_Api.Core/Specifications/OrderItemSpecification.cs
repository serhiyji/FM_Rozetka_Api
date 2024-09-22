using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Specifications
{
    public static class OrderItemSpecification
    {
        public class GetByOrderId : Specification<OrderItem>
        {
            public GetByOrderId(int orderId)
            {
                Query.Where(t => t.OrderId == orderId);
            }
        }
    }
}
