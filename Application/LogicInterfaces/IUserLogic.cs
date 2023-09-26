using Shared.DTOs;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User>CreateUserAsync(UserCreationDto userToCreate);
    Task<IEnumerable<User>>GetUserAsync(SearchUserParametersDto searchParameters);
}