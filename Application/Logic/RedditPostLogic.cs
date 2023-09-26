using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs.RedditPost;
using Shared.Models;

namespace Application.Logic;

public class RedditPostLogic : IRedditPostLogic
{
    
    private readonly IRedditPostDao redditPostDao;
    private readonly IUserDao userDao;
    
    public RedditPostLogic(IRedditPostDao redditPostDao, IUserDao userDao)
    {
        this.redditPostDao = redditPostDao;
        this.userDao = userDao;
    }
    
    public async Task<RedditPost> CreateRedditPostAsync(RedditPostCreationDto dto)
    {
        User? user = await userDao.GetByUsername(dto.Owner);
        if (user == null)
        {
            throw new Exception($"User with id {dto.Owner} was not found.");
        }

        ValidateRedditPost(dto);
            RedditPost redditPost = new RedditPost();
            RedditPost created = await redditPostDao.CreateRedditPostAsync(redditPost);
            return created;
    }

    public Task<IEnumerable<RedditPost>> GetRedditPost(SearchRedditPostParametersDto searchParameters)
    {
        return redditPostDao.GetRedditPost(searchParameters);
    }

    public async Task UpdateRedditPostAsync(RedditPostUpdateDto redditPost)
    {
        RedditPost? existing = await redditPostDao.GetRedditPostById(redditPost.Id);
        
        if (existing == null)
        {
            throw new Exception(message: $"RedditPost with ID {redditPost.Id} not found!");
        }
        
        User? user = null;
        if (redditPost.Owner != null)
        {
            user = await userDao.GetByUsername(redditPost.Owner);
            if (user == null)
            {
                throw new Exception($"User with id {redditPost.Owner} was not found.");
            }
        }
        User userToUse = user ?? existing.User;
        string titleToUse = redditPost.Title ?? existing.Title;

        RedditPost updated = new RedditPost()
        {
            Id = existing.Id,
        };
        ValidateRedditPost(updated);
        await redditPostDao.UpdateRedditPostAsync(updated);
    }

    public async Task DeleteRedditPost(int id)
    {
        RedditPost? existing = await redditPostDao.GetRedditPostById(id);
        if (existing == null)
        {
            throw new Exception(message: $"RedditPost with ID {id} not found!");
        }
        await redditPostDao.DeleteRedditPost(id);
    }

    public Task<RedditPost> GetRedditPostById(int id)
    {
        return redditPostDao.GetRedditPostById(id);
    }

    private void ValidateRedditPost(RedditPostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
    }

    private void ValidateRedditPost(RedditPost redditPost)
    {
        if (string.IsNullOrEmpty(redditPost.Title)) throw new Exception("Title cannot be empty.");
    }
}