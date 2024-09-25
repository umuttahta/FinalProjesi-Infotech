using ChocolateApp.Data.Abstract;
using ChocolateApp.Data.Concrete.EfCore.Repositories;
using ChocolateApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCartItemRepository : EfCoreGenericRepository<CartItem>, ICartItemRepository
    {
        public EfCoreCartItemRepository(ChocolateAppDbContext chocolateAppDbContext) : base(chocolateAppDbContext)
        {
        }
    }
}
