using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using KasetMore.ApplicationCore.Models;
using KasetMore.Data.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using KasetMore.Data.Repositories.Interfaces;

namespace KasetMore.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        //private readonly IValidator<LoginModel> _loginValidator;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public async Task<(string?, string?)> Authenticate(LoginModel request)
        {
            var result = await _userRepository.GetUserByEmail(request.Email);
            return result switch
            {
                null => (null, null),
                var user when user.Password != request.Password => (null, null),
                _ => (GenerateJwtToken(request.Email, "User"), result.ProfilePicture)
            };
            //var result = await _loginValidator.ValidateAsync(request);
            //if (result.IsValid)
            //{
            //    return GenerateJwtToken(request.Email, request.Password);
            //}
            //return null;
        }
        private string GenerateJwtToken(string name, string userType)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Name", name),
                new Claim("UserType", userType)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("Jwt:Key").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: creds
                );
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }
    }
}
