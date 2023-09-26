using Shared.DTOs.RedditPost;

namespace Application.DaoInterfaces;

public interface IRedditPostDao
{
    Task<RedditPost>CreateRedditPost(RedditPost redditPost);
    Task<IEnumerable<RedditPost>> GetRedditPosts(SearchRedditPostParametersDto searchParameters);
    Task UpdateRedditPost(RedditPost redditPost);
    Task<RedditPost> GetRedditPostById(int id);
    Task DeleteRedditPost(int id);
}