namespace Shared.DTOs.RedditPost;

public class RedditPostCreationDto
{
    public int OwnerId { get; }
    public string Title { get; }

    public RedditPostCreationDto(int ownerId, string title)
    {
        OwnerId = ownerId;
        Title = title;
    }
}