using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities.NovaPost;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FM_Rozetka_Api.Core.Specifications.NovaPost
{
    public class SettlementSpecification
    {
        public class SettlementSingleOrDefault : Specification<Settlement>
        {
            public SettlementSingleOrDefault(string settlementRef)
            {
                Query.Where(x => x.Ref == settlementRef);
            }
        }

        public class SettlementByDescriptionAndArea : Specification<Settlement>
        {
            public SettlementByDescriptionAndArea(string areaRef, string description)
            {
                Query.Where(x => x.Area.Ref == areaRef && EF.Functions.Like(x.Description, $"%{description}%"));
            }
        }
    }
}
