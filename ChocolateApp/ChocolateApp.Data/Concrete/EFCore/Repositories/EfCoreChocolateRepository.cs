using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChocolateApp.Data.Abstract;
using ChocolateApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ChocolateApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreChocolateRepository : EfCoreGenericRepository<Chocolate>, IChocolateRepository
    {
        public EfCoreChocolateRepository(ChocolateAppDbContext chocolateAppDbContext)
            : base(chocolateAppDbContext) { }

        private ChocolateAppDbContext Context
        {
            get { return _dbContext as ChocolateAppDbContext; }
        }

        public async Task ClearChocolateCategoriesAsync(int chocolateId)
        {
            List<ChocolateCategory> chocolateCategories = await Context
                .ChocolateCategories
                .Where(cc => cc.ChocolateId == chocolateId)
                .ToListAsync();
            Context.ChocolateCategories.RemoveRange(chocolateCategories);
            await Context.SaveChangesAsync();
        }

        public async Task<Chocolate> CreateChocolateWithCategoriesAsync(Chocolate chocolate, List<int> categoryIds)
        {
            var createdChocolate = await Context.Chocolates.AddAsync(chocolate);
            if (createdChocolate != null)
            {
                await Context.SaveChangesAsync();
                var chocolateCategories = categoryIds
                    .Select(x => new ChocolateCategory { ChocolateId = chocolate.Id, CategoryId = x })
                    .ToList();
                await Context.ChocolateCategories.AddRangeAsync(chocolateCategories);
                await Context.SaveChangesAsync();
            }
            var result = await GetChocolateWithCategoriesAsync(chocolate.Id);
            return result;
        }

        public async Task<List<Chocolate>> GetActiveChocolatesAsync(bool isActive)
        {
            List<Chocolate> chocolates = await Context
                .Chocolates
                .Where(c => c.IsActive == isActive)
                .Include(c => c.ChocolateCategories)
                .ThenInclude(cc => cc.Category)
                .ToListAsync();
            return chocolates;
        }

        public async Task<List<Chocolate>> GetChocolatesByCategoryIdAsync(int categoryId)
        {
            List<Chocolate> chocolates = await Context
                .Chocolates.Include(x => x.ChocolateCategories)
                .ThenInclude(y => y.Category)
                .Where(x => x.ChocolateCategories.Any(y => y.CategoryId == categoryId))
                .ToListAsync();
            return chocolates;
        }

        public async Task<List<Chocolate>> GetChocolatesWithCategoriesAsync()
        {
            List<Chocolate> chocolates = await Context
                .Chocolates
                .Include(x => x.ChocolateCategories)
                .ThenInclude(y => y.Category)
                .ToListAsync();
            return chocolates;
        }

        public async Task<Chocolate> GetChocolateWithCategoriesAsync(int id)
        {
            Chocolate chocolate = await Context
                .Chocolates.Where(x => x.Id == id)
                .Include(x => x.ChocolateCategories)
                .ThenInclude(y => y.Category)
                .FirstOrDefaultAsync();
            return chocolate;
        }

        // Optional method for updating chocolates with categories
        // public Task<Chocolate> UpdateChocolateWithCategoriesAsync(Chocolate chocolate, List<int> categoryIds)
        // {
        //     throw new NotImplementedException();
        // }
    }
}
