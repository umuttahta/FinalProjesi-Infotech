using System;
using Microsoft.AspNetCore.Http;
using ChocolateApp.Shared.Dtos;
using ChocolateApp.Service.Abstract;
using ChocolateApp.Service.Concrete;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace ChocolateApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;

        public CartsController(ICartService cartService, ICartItemService cartItemService)
        {
            _cartService=cartService;
            _cartItemService=cartItemService;
        }

        [HttpGet("initialize/{userId}")]
        public async Task<IActionResult> Initialize(string userId)
        {
            var response = await _cartService.InitializeCartAsync(userId);
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }

        [HttpGet("getcart/{userId}")]
        public async Task<IActionResult> GetCartByUserId(string userId)
        {
            var response = await _cartService.GetCartByUserIdAsync(userId);
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(AddToCartDto addToCartDto)
        {
            var response = await _cartItemService.AddToCartAsync(addToCartDto);
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }

        [HttpGet("deleteitem/{itemId}")]
        public async Task<IActionResult> DeleteItem(int itemId)
        {
            var response = await _cartItemService.DeleteItemFromCartAsync(itemId);
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }

        [HttpGet("clear/{userId}")]
        public async Task<IActionResult> ClearCart(string userId)
        {
            var response = await _cartItemService.ClearCartAsync(userId);
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }

        [HttpPost("changequantity")]
        public async Task<IActionResult> ChangeQuantity(int cartItemId, int quantity)
        {
            var response = await _cartItemService.ChangeQuantityAsync(cartItemId, quantity);
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }

    }
}