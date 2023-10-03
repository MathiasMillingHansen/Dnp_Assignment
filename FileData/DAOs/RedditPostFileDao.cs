using Application.DaoInterfaces;
using Shared.DTOs.RedditPost;
using Shared.Models;

namespace FileData.DAOs;

public class RedditPostFileDao : IRedditPostDao
{
    private readonly FileContext context;

    public RedditPostFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<RedditPost> CreateRedditPostAsync(RedditPost redditPost)
    {
        int postId = 1;
        /*
        if(context.Posts != null)
        {
            postId = context.Posts.Count + 1;
        }
        */

        redditPost.Id = postId;
        
        context.Posts.Add(redditPost);
        context.SaveChanges();
        context.UpdateUserPostList(redditPost);

        return Task.FromResult(redditPost);
    }

    public Task<ICollection<RedditPost>?> GetByUsernameAsync(string username)
    {
        ICollection<RedditPost> postsByUsername = new List<RedditPost>();

        foreach (RedditPost _redditPost in context.Posts)
        {
            if (_redditPost.User.Username.Equals(username))
            {
                postsByUsername.Add(_redditPost);
            }
        }
        return Task.FromResult(postsByUsername);
    }

    /*public Task<RedditPost> CreateRedditPostAsync(RedditPost redditPost)
    {
        context.Posts.Add(redditPost);
        context.SaveChanges();
        return Task.FromResult(redditPost);
    }*/

    public Task<IEnumerable<RedditPost>> GetRedditPost(SearchRedditPostParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task UpdateRedditPostAsync(RedditPost redditPostToUpdate)
    {
        context.SaveChanges();
        return Task.FromResult(redditPostToUpdate);
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