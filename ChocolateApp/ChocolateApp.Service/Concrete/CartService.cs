using AutoMapper;
using ChocolateApp.Data.Abstract;
using ChocolateApp.Entity.Concrete;
using ChocolateApp.Service.Abstract;
using ChocolateApp.Shared.Dtos;
using ChocolateApp.Shared.ResponseDtos;
using System.Threading.Tasks;

namespace ChocolateApp.Service.Concrete
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<Response<CartDto>> GetCartByUserIdAsync(string userId)
        {
            Cart cart = await _cartRepository.GetCartByUserIdAsync(userId);
            return Response<CartDto>.Success(_mapper.Map<CartDto>(cart), 200);
        }

        public async Task<Response<NoContent>> InitializeCartAsync(string userId)
        {
            Cart cart = new Cart { UserId = userId };
            await _cartRepository.CreateAsync(cart);
            return Response<NoContent>.Success(201);
        }
    }
}