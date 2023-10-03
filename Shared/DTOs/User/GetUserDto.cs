namespace Shared.DTOs.User;

public class GetUserDto
{
    public string Username { get; set; }
    
    public GetUserDto(string username)
    {
        Username = username;
    }
}