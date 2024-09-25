using ChocolateApp.Shared.Dtos;
using ChocolateApp.Shared.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateApp.Service.Abstract
{
    public interface ICartItemService
    {
        Task<Response<NoContent>> AddToCartAsync(AddToCartDto AddToCartDto);
        Task<Response<NoContent>> ClearCartAsync(string userId);
        Task<Response<NoContent>> DeleteItemFromCartAsync(int cartItemId);
        Task<Response<NoContent>> ChangeQuantityAsync(int cartItemId, int quantity);
    }
}
