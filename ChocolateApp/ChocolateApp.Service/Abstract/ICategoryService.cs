using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChocolateApp.Shared;
using ChocolateApp.Shared.Dtos;
using ChocolateApp.Shared.ResponseDtos;

namespace ChocolateApp.Service.Abstract
{
    public interface ICategoryService
    {
        Task<Response<CategoryDto>> AddAsync(AddCategoryDto addCategoryDto);
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<List<CategoryDto>>> GetActiveCategoriesAsync();
        Task<Response<CategoryDto>> GetByIdAsync (int id);
        Task<Response<CategoryDto>> UpdateAsync(EditCategoryDto editCategoryDto);
        Task<Response<NoContent>> DeleteAsync(int id);
    }
}