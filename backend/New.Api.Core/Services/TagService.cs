using AutoMapper;
using Microsoft.EntityFrameworkCore;
using New.Api.Core.Interfaces;
using News.Database;
using News.Database.Entities;

namespace New.Api.Core.Services
{
    public class TagsService : ITagsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TagsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<Tag>> GetAll()
        {
            return await _unitOfWork.Get<Tag>()
                .ToListAsync();
        }
    }
}
