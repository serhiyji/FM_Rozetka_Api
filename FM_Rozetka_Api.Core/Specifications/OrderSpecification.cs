﻿using Ardalis.Specification;
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

        public class GetShopOrderStatistics : Specification<Order>
        {
           public GetShopOrderStatistics(int shopId)
            {
                var now = DateTime.UtcNow;
                var lastWeek = now.AddDays(-7);

                Query.Where(order => order.OrderDate >= lastWeek)
                     .Include(order => order.OrderItems)
                     .ThenInclude(orderItem => orderItem.Product)
                     .Where(order => order.OrderItems.Any(oi => oi.Product.ShopId == shopId));
            }
        }

        public class GetAllOrdersStatistics : Specification<Order>
        {
            public GetAllOrdersStatistics()
            {
                var now = DateTime.UtcNow;
                var lastWeek = now.AddDays(-7);

                Query.Where(order => order.OrderDate >= lastWeek)
                     .Include(order => order.OrderItems)
                     .ThenInclude(orderItem => orderItem.Product);
            }
        }

        public class GetOrderByShopId : Specification<Order>
        {
            public GetOrderByShopId(int shopId)
            {
                Query.Include(order => order.OrderItems)
                     .ThenInclude(orderItem => orderItem.Product)
                     .Where(order => order.OrderItems.Any(oi => oi.Product.ShopId == shopId));
            }
        }

        public class GetAllOrders : Specification<Order>
        {
            public GetAllOrders()
            {
                Query.Include(order => order.OrderItems)
                     .ThenInclude(orderItem => orderItem.Product);
            }
        }

        public class GetAllOrdersByUserId : Specification<Order>
        {
            public GetAllOrdersByUserId(string appUserId)
            {
                Query.Where(order => order.AppUserId == appUserId)
                     .Include(order => order.OrderItems)
                     .ThenInclude(orderItem => orderItem.Product);
            }
        }

        public class GetOrdersForLast7Days : Specification<Order>
        {
            public GetOrdersForLast7Days()
            {
                var sevenDaysAgo = DateTime.UtcNow.AddDays(-7);

                Query.Include(order => order.OrderItems)
                     .ThenInclude(orderItem => orderItem.Product)
                     .Where(order => order.OrderDate >= sevenDaysAgo);
            }
        }

    }
}
