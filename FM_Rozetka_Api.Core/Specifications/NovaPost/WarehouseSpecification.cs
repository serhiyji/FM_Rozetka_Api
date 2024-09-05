using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities.NovaPost;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Specifications.NovaPost
{
    public class WarehouseSpecification
    {
        public class WarehouseSingleOrDefault : Specification<Warehouse>
        {
            public WarehouseSingleOrDefault(string warehouseRef)
            {
                Query.Where(x => x.Ref == warehouseRef);
            }
        }

        public class WarehouseBySettlementAndDescription : Specification<Warehouse>
        {
            public WarehouseBySettlementAndDescription(string settlementRef, string description)
            {
                Query.Where(w => w.Settlement.Ref == settlementRef).Where(w => EF.Functions.Like(w.Description, $"%{description}%"));
            }
        }
    }


}
