using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Models;

namespace WebAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly IUserLogic UserLogic;

    public UserController(IUserLogic Userlogic)
    {
        this.UserLogic = UserLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<User>> CreateAsync([FromBody] UserCreationDto dto)
    {
        try
        {
            User user = await UserLogic.CreateUserAsync(dto);
            return Created($"/users/{user.Username}", user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    

}