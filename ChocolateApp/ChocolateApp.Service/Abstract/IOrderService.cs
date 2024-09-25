using ChocolateApp.Shared.Dtos;
using ChocolateApp.Shared.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateApp.Service.Abstract
{
    public interface IOrderService
    {
        Task<Response<NoContent>> CreateAsync(OrderDto orderDto);
        Task<Response<OrderDto>> GetOrderAsync(int orderId);
        Task<Response<List<OrderDto>>> GetAllOrdersAsync(string? userId = null);
    }
}
