using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PrintLayer.Models;

namespace PrintLayer.Services.Interfaces
{
    public interface IImageService : ICommonService<Image>
    {
        Task AddAsync(IFormFile file);
    }
}
