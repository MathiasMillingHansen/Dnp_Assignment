namespace Shared.DTOs.RedditPost;

public class RedditPostUpdateDto
{
    public int Id { get; }
    public string Body { get; set; }

    public RedditPostUpdateDto(int id, string body)
    {
        Id = id;
        Body = body;
    }
}