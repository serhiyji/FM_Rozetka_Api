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
    public class DiscountSpecifications
    {
        public class GetExpiredDiscounts : Specification<Discount>
        {
            public GetExpiredDiscounts()
            {
                Query.Where(d => d.EndDate < DateTime.UtcNow);
            }
        }

        public class GetUpcomingDiscounts : Specification<Discount>
        {
            public GetUpcomingDiscounts()
            {
                Query.Where(d => d.StartDate <= DateTime.Now && d.EndDate > DateTime.Now);
            }
        }

    }
}
