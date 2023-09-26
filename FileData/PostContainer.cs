using Shared.Models;

namespace FileContext;

public class PostContainer
{
    public ICollection<RedditPost> Posts { get; set; }
    
}