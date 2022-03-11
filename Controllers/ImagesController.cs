using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrintLayer.Models;
using PrintLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintLayer.Controllers
{
    [Route("[controller]")]
    public class ImagesController : Controller
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        public async Task Add([FromForm] IFormFile file)
        {
            await _imageService.AddAsync(file);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Image> Get(Guid id)
        {
            var image = await _imageService.FindAsync(id);
            return image;
        }
    }
}
