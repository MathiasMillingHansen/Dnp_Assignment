using Shared.DTOs;
using Shared.Models;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateUser(User user);
    Task<User?> GetByUsername(string userName);
    public Task<IEnumerable<User>> GetUser(SearchUserParametersDto searchParameters);
    Task<User?> GetById(int id);
}