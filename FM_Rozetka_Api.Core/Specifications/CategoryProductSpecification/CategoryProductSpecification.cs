using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FM_Rozetka_Api.Core.Specifications.CategoryProductSpecification
{
    public static class CategoryProductSpecification
    {
        public class GetCountSubcategories : Specification<CategoryProduct>
        {
            public GetCountSubcategories(int id)
            {
                Query.Where(x => x.TopId == id);
            }
        }
    }
}
