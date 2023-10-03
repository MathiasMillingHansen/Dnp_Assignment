using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.RedditPost;
using Shared.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class RedditPostController : ControllerBase
{
    private readonly IRedditPostLogic _redditPostLogic;

    public RedditPostController(IRedditPostLogic redditPostLogic)
    {
        _redditPostLogic = redditPostLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<RedditPost>> CreateAsync(RedditPostCreationDto dto)
    {
        try
        {
            RedditPost redditPost = await _redditPostLogic.CreateRedditPostAsync(dto);
            return Created($"/posts/{redditPost.Id}", redditPost);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RedditPost>>> GetAllAsync()
    {
        try
        {
            IEnumerable<RedditPost> redditPosts = await _redditPostLogic.GetRedditPostAsync();
            return Ok(redditPosts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    /*[HttpGet]
    public async Task<ActionResult<RedditPost>> GetByIdAsync([FromQuery] int id)
    {
        try
        {
            RedditPost redditPost = await _redditPostLogic.GetRedditPostById(id);
            return Ok(redditPost);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }*/


}