using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using New.Api.Core.Interfaces;
using News.Database;
using News.Database.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using New.Api.Core.Models;

namespace New.Api.Core.Services
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private const double defaultTime = 100d;

        public LoginService(IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDto> LoginUser(string login, string password)
        {
            var author = await _unitOfWork.Get<Author>()
                .FirstOrDefaultAsync(e => e.Login == login && e.Password == password);

            if (author == null)
                return null;

            var user = _mapper.Map<UserDto>(author);
            user.Token = GenerateJwtToken();

            return user;
        }

        private string GenerateJwtToken()
        {
            if (string.IsNullOrEmpty(_configuration.GetSection("Authentication:Key").Value))
                throw new ArgumentException("Key hasn't been provided");

            var timeNow = DateTime.Now;
            var timeSpan = double.TryParse(_configuration.GetSection("Authentication:LifeSpan").Value, out double time)
                         ? time : defaultTime;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("Authentication:Key").Value);
            var descriptor = new SecurityTokenDescriptor
            {
                NotBefore = timeNow,
                Expires = timeNow.AddMinutes(timeSpan),
                Audience = _configuration.GetSection("Authentication:Audiance").Value,
                Issuer = _configuration.GetSection("Authentication:Issuer").Value,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(descriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
