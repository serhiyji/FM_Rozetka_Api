using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities.NovaPost;
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
    }


}
