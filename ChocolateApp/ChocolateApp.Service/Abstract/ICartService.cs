using ChocolateApp.Shared.Dtos;
using ChocolateApp.Shared.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateApp.Service.Abstract
{
    public interface ICartService
    {
        Task<Response<NoContent>> InitializeCartAsync(string userId);
        Task<Response<CartDto>> GetCartByUserIdAsync(string userId);
     
    }
}
