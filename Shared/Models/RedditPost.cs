namespace Shared.Models;

public class RedditPost
{
    public string Title { get; set; }
    public string Body { get; set; }
    public User User { get; set; }
    public int Id { get; set; }

    public RedditPost(string Title, string Body, User User)
    {
        this.Title = Title;
        this.Body = Body;
        this.User = User;
    }
}