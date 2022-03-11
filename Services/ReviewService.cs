using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrintLayer.Models;
using PrintLayer.Repositories.Interfaces;
using PrintLayer.Services.Interfaces;

namespace PrintLayer.Services
{
    public class ReviewService : CommonService<Review>, IReviewService
    {
        private readonly IGenericRepository<Review> _repository;

        public ReviewService(IGenericRepository<Review> repository) : base(repository)
        {
            _repository = repository;
        }

    }
}
