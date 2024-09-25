using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChocolateApp.Shared;
using ChocolateApp.Shared.Dtos;
using ChocolateApp.Shared.ResponseDtos;

namespace ChocolateApp.Service.Abstract
{
    public interface IChocolateService
    {
        Task<Response<ChocolateDto>> AddAsync(AddChocolateDto addChocolateDto);
        Task<Response<List<ChocolateDto>>> GetAllAsync();
        Task<Response<List<ChocolateDto>>> GetChocolatesWithCategoriesAsync();
        Task<Response<List<ChocolateDto>>> GetChocolatesByCategoryIdAsync(int categoryId);
        Task<Response<ChocolateDto>> UpdateAsync(EditChocolateDto editChocolateDto);
        Task<Response<ChocolateDto>> GetByIdAsync (int id);
        Task<Response<NoContent>> DeleteAsync (int id);
        Task<Response<List<ChocolateDto>>> GetActiveChocolatesAsync(bool isActive = true);
    }
}