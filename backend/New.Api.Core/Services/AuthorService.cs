using AutoMapper;
using Microsoft.EntityFrameworkCore;
using New.Api.Core.Interfaces;
using News.Database;
using News.Database.Entities;

namespace New.Api.Core.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthorsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<Author>> GetAll()
        {
            return await _unitOfWork.Get<Author>()
                .ToListAsync();
        }
    }
}
