using Application.DaoInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace FileContext.DAOs;

public class UserFileDao : IUserDao
{
    private readonly FileContext context;

    public UserFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<User> CreateAsync(User user)
    {
        if (context.Users.Any())
        {
            foreach (User _user in context.Users)
            {
                if (_user.Username.Equals(user.Username))
                {
                    throw new ArgumentException("Username unavailable");
                }
            }
        }

        context.Users.Add(user);
        context.SaveChanges();

        return Task.FromResult(user);
    }

    public Task<User?> GetByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<User> CreateUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByUsername(string userName)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetUser(SearchUserParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetById(int id)
    {
        throw new NotImplementedException();
    }
}