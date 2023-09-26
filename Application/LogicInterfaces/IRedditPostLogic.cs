using Shared.DTOs.RedditPost;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IRedditPostLogic
{
    Task<RedditPost> CreateRedditPostAsync(RedditPostCreationDto dto);
    Task<IEnumerable<RedditPost>> GetRedditPost(SearchRedditPostParametersDto searchParameters);
    Task UpdateRedditPostAsync(RedditPostUpdateDto redditPost);
    Task DeleteRedditPost(int id);
    Task<RedditPost> GetRedditPostById(int id);
}