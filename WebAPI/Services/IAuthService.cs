using Shared.DTOs.User;
using Shared.Models;

namespace WebAPI.Services;

public interface IAuthService
{
    Task<User> GetUser(string username, string password);
    Task<User> RegisterUser(User user);

    Task<User> ValidateTheUser(GetUserWithPasswordDto user);
}