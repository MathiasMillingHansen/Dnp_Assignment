using Shared.DTOs.RedditPost;

namespace Clients.ClientInterfaces;

public interface IRedditPostService
{
    Task CreatePostAsync(RedditPostCreationDto postToCreate);
    
}