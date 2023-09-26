using Shared.Models;

namespace Shared.DTOs.RedditPost;

public class RedditPostCreationDto
{
    public User Owner { get; }
    public string Title { get; }
    public string Body { get; }

    public RedditPostCreationDto(User owner, string body, string title)
    {
        Owner = owner;
        Body = body;
        Title = title;
    }
}