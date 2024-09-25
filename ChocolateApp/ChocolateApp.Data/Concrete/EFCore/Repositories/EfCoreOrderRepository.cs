using ChocolateApp.Data.Abstract;
using ChocolateApp.Data.Concrete.EfCore.Repositories;
using ChocolateApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreOrderRepository : EfCoreGenericRepository<Order>, IOrderRepository
    {
        public EfCoreOrderRepository(ChocolateAppDbContext chocolateAppDbContext) : base(chocolateAppDbContext) { }

        private ChocolateAppDbContext Context
        {
            get { return _dbContext as ChocolateAppDbContext; }
        }

        public async Task<List<Order>> GetAllOrdersAsync(string userId = null)
        {
            if (userId == null)
            {
                return await Context
                    .Orders
                    .Include(x => x.OrderItems)
                    .ThenInclude(y => y.chocolate)
                    .ToListAsync();
            }

            return await Context
                .Orders
                .Where(x => x.UserId == userId)
                .Include(x => x.OrderItems)
                .ThenInclude(y => y.chocolate)
                .ToListAsync();
        }

        public async Task<Order> GetOrderAsync(int orderId)
        {
            return await Context
                .Orders
                .Where(x => x.Id == orderId)
                .Include(x => x.OrderItems)
                .ThenInclude(y => y.chocolate)
                .FirstOrDefaultAsync();
        }
    }
}
