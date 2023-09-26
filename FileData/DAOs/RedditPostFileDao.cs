using Application.DaoInterfaces;
using Shared.DTOs.RedditPost;
using Shared.Models;

namespace FileContext.DAOs;

public class RedditPostFileDao : IRedditPostDao
{
    private readonly FileContext context;

    public RedditPostFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<RedditPost> CreateAsync(RedditPost redditPost)
    {
        int postId = 1;
        if (context.Posts.Any())
        {
            postId = context.Posts.Max(p => p.Id);
            postId++;
        }

        redditPost.Id = postId;
        
        context.Posts.Add(redditPost);
        context.SaveChanges();

        return Task.FromResult(redditPost);
    }

    public Task<RedditPost?> GetByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<RedditPost> CreateRedditPost(RedditPost redditPost)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<RedditPost>> GetRedditPosts(SearchRedditPostParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task UpdateRedditPost(RedditPost redditPost)
    {
        throw new NotImplementedException();
    }

    public Task<RedditPost> GetRedditPostById(int id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteRedditPost(int id)
    {
        throw new NotImplementedException();
    }
}