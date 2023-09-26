using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<User> CreateUser(UserCreationDto userToCreate)
    {
        User? existing = await userDao.GetByUsername(userToCreate.UserName);
        if (existing != null)
            throw new Exception("Username already taken!");
        ValidateData(userToCreate);
        User toCreate = new User(userToCreate.UserName, userToCreate.Password);
    
        User created = await userDao.CreateUser(toCreate);
    
        return created;
    }

    public Task<IEnumerable<User>> GetUser(SearchUserParametersDto searchParameters)
    {
        return userDao.GetUser(searchParameters);
    }
    
    private static void ValidateData(UserCreationDto userToCreate)
    {
        string userName = userToCreate.UserName;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
    }

    public Task<User> CreateUserAsync(UserCreationDto userToCreate)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetUserAsync(SearchUserParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }
}