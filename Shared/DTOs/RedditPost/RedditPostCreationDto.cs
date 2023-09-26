namespace Shared.DTOs.RedditPost;

public class RedditPostCreationDto
{
    public string Owner { get; }
    public string Title { get; }

    public RedditPostCreationDto(string owner, string title)
    {
        Owner = owner;
        Title = title;
    }
}