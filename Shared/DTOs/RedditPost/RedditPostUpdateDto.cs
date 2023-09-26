namespace Shared.DTOs.RedditPost;

public class RedditPostUpdateDto
{
    public int Id { get; }
    public int? OwnerId { get; set; }
    public string? Title { get; set; }

    public RedditPostUpdateDto(int id)
    {
        Id = id;
    }
}