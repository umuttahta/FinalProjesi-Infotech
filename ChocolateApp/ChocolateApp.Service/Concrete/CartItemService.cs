using AutoMapper;
using ChocolateApp.Data.Abstract;
using ChocolateApp.Entity.Concrete;
using ChocolateApp.Service.Abstract;
using ChocolateApp.Shared.Dtos;
using ChocolateApp.Shared.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateApp.Service.Concrete
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartItemService(ICartItemRepository cartItemRepository, IMapper mapper, ICartRepository cartRepository)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
            _cartRepository = cartRepository;
        }

        public async Task<Response<NoContent>> AddToCartAsync(AddToCartDto AddToCartDto)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(AddToCartDto.UserId);
            if (cart == null)
            {
                return Response<NoContent>.Fail("Bir hata oluştu", 400);
            }

            int index = cart.CartItems.FindIndex(x => x.ProductId == AddToCartDto.ProductId);
            if (index < 0) 
            {
                cart.CartItems.Add(new CartItem
                {
                    ProductId = AddToCartDto.ProductId,
                    CartId = cart.Id,
                    Quantity = AddToCartDto.Quantity
                });
            }
            else 
            {
                cart.CartItems[index].Quantity += AddToCartDto.Quantity;
            }

            await _cartRepository.UpdateAsync(cart);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> ChangeQuantityAsync(int cartItemId, int quantity)
        {
            CartItem cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
            cartItem.Quantity = quantity;
            await _cartItemRepository.UpdateAsync(cartItem);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> ClearCartAsync(string userId)
        {
            Cart cart = await _cartRepository.GetCartByUserIdAsync(userId);
            cart.CartItems = new List<CartItem>();
            await _cartRepository.UpdateAsync(cart);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<NoContent>> DeleteItemFromCartAsync(int cartItemId)
        {
            CartItem cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
            await _cartItemRepository.DeleteAsync(cartItem);
            return Response<NoContent>.Success(200);
        }
    }
}
