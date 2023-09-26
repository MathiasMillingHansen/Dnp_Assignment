namespace Shared.DTOs.RedditPost;

public class RedditPostUpdateDto
{
    public int Id { get; }
    public string Owner { get; set; }
    public string? Title { get; set; }

    public RedditPostUpdateDto(int id)
    {
        Id = id;
    }
}