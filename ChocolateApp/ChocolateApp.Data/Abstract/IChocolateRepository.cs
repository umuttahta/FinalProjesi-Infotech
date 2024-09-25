using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChocolateApp.Data.Abstract;
using ChocolateApp.Entity.Concrete;

namespace ChocolateApp.Data.Abstract
{
    public interface IChocolateRepository:IGenericRepository<Chocolate>
    {
        Task<List<Chocolate>> GetChocolatesWithCategoriesAsync();
        Task<Chocolate> GetChocolateWithCategoriesAsync(int id);
        Task<List<Chocolate>> GetChocolatesByCategoryIdAsync(int categoryId);
        Task<Chocolate> CreateChocolateWithCategoriesAsync(Chocolate chocolate, List<int> categoryIds);
        Task ClearChocolateCategoriesAsync(int ChocolateId);
        Task<List<Chocolate>> GetActiveChocolatesAsync(bool isActive);

    }
}