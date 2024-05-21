using KasetMore.ApplicationCore.Models;
using KasetMore.Data.Models;
using KasetMore.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace KasetMore.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly KasetMoreContext _context;

        public UserRepository(KasetMoreContext context)
        {
            _context = context;
        }

        public async Task<UserDto?> GetUserByEmail(string email)
        {
            return await _context.Users
                .Where(u => u.Email == email)
                .Select(u => new UserDto
                {
                    Email = u.Email,
                    Password = u.Password,
                    DisplayName = u.DisplayName,
                    ProfilePicture = u.ProfilePicture,
                })
                .FirstOrDefaultAsync();
        }
        public async Task Register(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            } 
            catch(Exception)
            {
                throw;
            }
        }
        public async Task UpdateProfile(User userRequest)
        {
            try
            {
                _context.Users.Update(userRequest);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateProfilePicture(IFormFile profilePicture, string email)
        {
            try
            {
                using var memoryStream = new MemoryStream();
                profilePicture.CopyTo(memoryStream);
                var base64 = Convert.ToBase64String(memoryStream.ToArray());
                await _context.Users
                    .Where(u => u.Email == email)
                    .ExecuteUpdateAsync(u => u.SetProperty(u => u.ProfilePicture, base64));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateVerifyFlag(string email, string flag)
        {
            try
            {
                await _context.Users
                    .Where(u => u.Email == email)
                    .ExecuteUpdateAsync(u => u.SetProperty(u => u.IsVerified, flag));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
