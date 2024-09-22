using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FM_Rozetka_Api.Core.Specifications
{
    public static class OrderSpecification
    {
        public class LastCreatedOrderSpec : Specification<Order>
        {
            public LastCreatedOrderSpec()
            {
                Query.OrderByDescending(o => o.Id).Take(1); 
            }
        }

        public class GetByOidreId : Specification<Order>
        {
            public GetByOidreId(string orderId)
            {
                Query.Where(t => t.OrderId == orderId);
            }
        }
    }
}
