using ChocolateApp.Shared.ResponseDtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateApp.Shared.Helpers.Abstract
{
    public interface IImageHelper
    {
        Task<Response<string>> Upload(IFormFile file);
    }
}
