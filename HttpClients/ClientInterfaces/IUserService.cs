using System;
using Shared.DTOs;
using Shared.DTOs.User;
using Shared.Models;

namespace ClientsHttpClients.ClientInterfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(UserCreationDto userToCreate);
        
    }
}