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
    public class EfCoreCartRepository : EfCoreGenericRepository<Cart>, ICartRepository
    {
        public EfCoreCartRepository(ChocolateAppDbContext coffeeAppDbContext) : base(coffeeAppDbContext)
        {
        }

        private ChocolateAppDbContext Context
        {
            get { return _dbContext as ChocolateAppDbContext; }
        }

        public async Task<Cart> GetCartByUserIdAsync(string userId)
        {
            return await Context
                .Carts
                .Where(x => x.UserId == userId)
                .Include(x => x.CartItems)
                .ThenInclude(y => y.ProductId) 
                .FirstOrDefaultAsync();
        }
    }
}

    