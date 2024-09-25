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
    public class ChocolateService : IChocolateService
    {         private readonly IChocolateRepository _ChocolateRepository;
        private readonly IMapper _mapper;

        public ChocolateService(IChocolateRepository ChocolateRepository, IMapper mapper)
        {
            _ChocolateRepository=ChocolateRepository;
            _mapper=mapper;
        }

        public async Task<Response<ChocolateDto>> AddAsync(AddChocolateDto addChocolateDto)
        {
            var Chocolate = _mapper.Map<Chocolate>(addChocolateDto);
            
            var createdChocolate = await _ChocolateRepository.CreateChocolateWithCategoriesAsync(Chocolate,addChocolateDto.CategoryIds);
            if (createdChocolate == null)
            {
                return Response<ChocolateDto>.Fail("Bir sorun oluştu", 404);
            }
            var ChocolateDto = _mapper.Map<ChocolateDto>(createdChocolate);
            return Response<ChocolateDto>.Success(ChocolateDto, 201);
        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var Chocolate = await _ChocolateRepository.GetByIdAsync(id);
            if (Chocolate == null)
            {
                return Response<NoContent>.Fail("Böyle bir ürün  bulunamadı", 404);
            }
            await _ChocolateRepository.DeleteAsync(Chocolate);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<ChocolateDto>>> GetActiveChocolateAsync(bool isActive = true)
        {
            List<Chocolate> Chocolate = await _ChocolateRepository.GetActiveChocolatesAsync(isActive);
            if (Chocolate.Count == 0)
            {
                return Response<List<ChocolateDto>>.Fail("istediğiniz kriterde ürün bulunamadı.", 404);
            }
            var ChocolateDtos = _mapper.Map<List<ChocolateDto>>(Chocolate);
            return Response<List<ChocolateDto>>.Success(ChocolateDtos, 200);
        }

        public async Task<Response<List<ChocolateDto>>> GetAllAsync()
        {
            var Chocolate = await _ChocolateRepository.GetChocolatesWithCategoriesAsync();
            if (Chocolate.Count==0)
            {
                return Response<List<ChocolateDto>>.Fail("Hiç ürün bulunamadı", 404);
            }
            var ChocolateDtos = _mapper.Map<List<ChocolateDto>>(Chocolate);
            return Response<List<ChocolateDto>>.Success(ChocolateDtos, 200);
        }

        public async Task<Response<List<ChocolateDto>>> GetChocolateByCategoryIdAsync(int categoryId)
        {
            var Chocolate = await _ChocolateRepository.GetChocolatesByCategoryIdAsync(categoryId);
            if(Chocolate.Count==0)
            {
                return Response<List<ChocolateDto>>.Fail("Bu kategoride hiç ürün bulunamadı", 404);
            }
            var ChocolateDtos = _mapper.Map<List<ChocolateDto>>(Chocolate);
            return Response<List<ChocolateDto>>.Success(ChocolateDtos, 200);
        }

        public async Task<Response<List<ChocolateDto>>> GetChocolateWithCategoriesAsync()
        {
            var Chocolate = await _ChocolateRepository.GetChocolatesWithCategoriesAsync();
            if (Chocolate.Count==0)
            {
                return Response<List<ChocolateDto>>.Fail("Hiç ürün bulunamadı", 404);
            }
            var ChocolateDtos = _mapper.Map<List<ChocolateDto>>(Chocolate);
            return Response<List<ChocolateDto>>.Success(ChocolateDtos, 200);
        }

        public async Task<Response<ChocolateDto>> GetByIdAsync(int id)
        {
            var Chocolate = await _ChocolateRepository.GetChocolateWithCategoriesAsync(id);
            if (Chocolate == null)
            {
                return Response<ChocolateDto>.Fail("Böyle bir ürün bulunamadı", 404);
            }
            var ChocolateDto = _mapper.Map<ChocolateDto>(Chocolate);
            return Response<ChocolateDto>.Success(ChocolateDto,200);
        }

        public async Task<Response<ChocolateDto>> UpdateAsync(EditChocolateDto editChocolateDto)
        {
            var Chocolate = _mapper.Map<Chocolate>(editChocolateDto);//Dönüştürme
            if(Chocolate == null)
            {
                return Response<ChocolateDto>.Fail("Bir hata oluştu", 400);
            }
            Chocolate.ModifiedDate=DateTime.Now;
            var updatedChocolate = await _ChocolateRepository.UpdateAsync(Chocolate);
            await _ChocolateRepository.ClearChocolateCategoriesAsync(updatedChocolate.Id);
            updatedChocolate.ChocolateCategories=editChocolateDto
                .CategoryIds
                .Select(categoryId => new ChocolateCategory
                {
                    ChocolateId=updatedChocolate.Id,
                    CategoryId=categoryId
                }).ToList();
            await _ChocolateRepository.UpdateAsync(updatedChocolate);
            var result = await _ChocolateRepository.GetChocolateWithCategoriesAsync(updatedChocolate.Id);
            var ChocolateDto = _mapper.Map<ChocolateDto>(result);
            return Response<ChocolateDto>.Success(ChocolateDto,200);
        }

        public Task<Response<List<ChocolateDto>>> GetChocolatesWithCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ChocolateDto>>> GetChocolatesByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ChocolateDto>>> GetActiveChocolatesAsync(bool isActive = true)
        {
            throw new NotImplementedException();
        }
    }
}
