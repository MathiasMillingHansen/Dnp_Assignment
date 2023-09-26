using Shared.Models;

namespace FileContext;

public class UserContainer
{
    public ICollection<User> Users { get; set; }
    
}