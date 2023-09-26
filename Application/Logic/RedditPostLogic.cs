using Application.DaoInterfaces;
using Application.LogicInterfaces;
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
    
    public async Task<RedditPost> CreateRedditPost(RedditPostCreationDto dto)
    {
        User? user = await userDao.GetById(dto.OwnerId);
        if (user == null)
        {
            throw new Exception($"User with id {dto.OwnerId} was not found.");
            
            ValidateRedditPost(dto);
            RedditPost redditPost = new RedditPost(user, dto.Title);
            RedditPost created = await redditPostDao.CreateRedditPost(redditPost);
            return created;
    }

    public Task<IEnumerable<RedditPost>> GetRedditPost(SearchRedditPostParametersDto searchParameters)
    {
        return redditPostDao.GetRedditPost(searchParameters);
    }

    public async Task UpdateRedditPost(RedditPostUpdateDto redditPost)
    {
        RedditPost? existing = await redditPostDao.GetRedditPostById(redditPost.Id);
        if (existing == null)
        {
            throw new Exception(message: $"RedditPost with ID {dto.Id} not found!");
        }
        
        User? user = null;
        if (dto.OwnerId != null)
        {
            user = await userDao.GetById((int)dto.OwnerId);
            if (user == null)
            {
                throw new Exception($"User with id {dto.OwnerId} was not found.");
            }
        }
        User userToUse = user ?? existing.Owner;
        string titleToUse = dto.Title ?? existing.Title;

        RedditPost updated = new(userToUse, titleToUse)
        {
            Id = existing.Id,
        };
        ValidateRedditPost(updated);
        await redditPostDao.UpdateRedditPost(updated);
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
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
    }
}