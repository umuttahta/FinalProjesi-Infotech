using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChocolateApp.Entity.Concrete;

namespace ChocolateApp.Data.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();              
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> UpdateAsync(TEntity entity);      
        Task DeleteAsync(TEntity entity);       

}
}