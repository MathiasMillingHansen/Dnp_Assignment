namespace Shared.DTOs.RedditPost;

public class SearchRedditPostParametersDto
{
    public string? Username { get;}
    public int? UserId { get;}
    public string? TitleContains { get;}

    public SearchRedditPostParametersDto(string? username, int? userId, string? titleContains)
    {
        Username = username;
        UserId = userId;
        TitleContains = titleContains;
    }
}