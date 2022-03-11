using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PrintLayer.Models;
using PrintLayer.Repositories.Interfaces;
using PrintLayer.Services.Interfaces;

namespace PrintLayer.Services
{
    public class ImageService : CommonService<Image>, IImageService
    {
        private readonly IGenericRepository<Image> _repository;

        public ImageService(IGenericRepository<Image> repository) : base(repository)
        {
            _repository = repository;
        }

        public virtual async Task AddAsync(IFormFile file)
        {
            Image entity = new Image
            {
                Name = file.FileName
            };
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                entity.Data = target.ToArray();
            }

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
        }
        
    }
}
