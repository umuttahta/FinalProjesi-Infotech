﻿using ChocolateApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateApp.Data.Abstract
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<List<Order>> GetAllOrdersAsync(string userId = null);
        Task<Order> GetOrderAsync(int orderId);
    }
}
