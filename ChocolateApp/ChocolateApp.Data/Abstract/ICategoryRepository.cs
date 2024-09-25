using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChocolateApp.Entity.Concrete;

namespace ChocolateApp.Data.Abstract
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        
        Task<List<Category>> GetActiveCategoriesAsync();
    }
}