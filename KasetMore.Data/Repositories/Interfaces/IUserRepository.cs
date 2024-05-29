using KasetMore.ApplicationCore.Models;
using KasetMore.Data.Models;
using Microsoft.AspNetCore.Http;

namespace KasetMore.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto?> GetUserByEmail(string email);
        Task<User?> AuthenticateUser(string email);
        Task Register(User user);
        Task UpdateProfile(User userRequest);
        Task UpdateProfilePicture(IFormFile profilePicture, string email);
        Task UpdateVerifyFlag(string email, string flag);
    }
}