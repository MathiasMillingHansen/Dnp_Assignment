using Shared.Models;

namespace FileContext;

public class DataContainer
{
    public ICollection<User> Users { get; set; }
    public ICollection<RedditPost> Posts { get; set; }
    
}