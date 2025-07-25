﻿using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.Specifications
{
    public static class FavoriteSpecification
    {
        public class GetByAppUserId : Specification<Favorite>
        {
            public GetByAppUserId(string appUserId)
            {
                Query.Where(item => item.AppUserId == appUserId).Include(item => item.Product);
            }
        }

        public class Exists : Specification<Favorite>
        {
            public Exists(string appUserId, int productId)
            {
                Query.Where(f => f.AppUserId == appUserId && f.ProductId == productId);
            }
        }
    }
}
