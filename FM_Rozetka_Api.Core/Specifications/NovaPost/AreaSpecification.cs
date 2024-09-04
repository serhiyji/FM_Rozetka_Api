using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities.NovaPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FM_Rozetka_Api.Core.Specifications.NovaPost
{
    public class AreaSpecification
    {
        public class AreaSingleOrDefault : Specification<Area>
        {
            public AreaSingleOrDefault(string AreaRef)
            {
                Query.Where(x => x.Ref == AreaRef);
            }
        }
    }
}
