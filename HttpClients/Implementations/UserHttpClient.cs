using System;
using ClientsHttpClients.ClientInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace ClientsHttpClients.Implementations
{
    public class UserHttpClient : IUserService
    {

        public Task<User> CreateUserAsync(UserCreationDto userToCreate)
        {
            throw new NotImplementedException();
        }
    }
}