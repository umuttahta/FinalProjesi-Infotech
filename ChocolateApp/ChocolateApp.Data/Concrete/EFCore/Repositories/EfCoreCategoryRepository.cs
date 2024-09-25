using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChocolateApp.Data.Abstract;
using ChocolateApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ChocolateApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(ChocolateAppDbContext chocolateAppDbContext)
            : base(chocolateAppDbContext) { }

        private ChocolateAppDbContext Context
        {
            get { return _dbContext as ChocolateAppDbContext; }
        }

        public async Task<List<Category>> GetActiveCategoriesAsync()
        {
            //LINQ to SQL ifadeleri
            List<Category> categories = await Context
                .Categories
                .Where(c => c.IsActive)
                .ToListAsync();
            return categories;
        }
    }
}
