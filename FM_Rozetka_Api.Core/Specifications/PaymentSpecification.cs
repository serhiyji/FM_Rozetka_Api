using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Specifications
{
    public static class PaymentSpecification
    {
        public class GetByOrderId : Specification<Payment>
        {
            public GetByOrderId(int orderId)
            {
                Query.Where(o => o.OrderId == orderId);
            }
        }

    }
}
