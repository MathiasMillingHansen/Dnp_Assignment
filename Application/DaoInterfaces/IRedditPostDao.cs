using Shared.DTOs.RedditPost;
using Shared.Models;

namespace Application.DaoInterfaces;

public interface IRedditPostDao
{
    Task<RedditPost>CreateRedditPost(RedditPost redditPost);
    Task<IEnumerable<RedditPost>> GetRedditPosts(SearchRedditPostParametersDto searchParameters);
    Task UpdateRedditPost(RedditPost redditPost);
    Task<RedditPost> GetRedditPostById(int id);
    Task DeleteRedditPost(int id);
}