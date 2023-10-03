namespace Shared.DTOs;

public class OwnerDto
{
    public string Username { get; set; }
    
    public OwnerDto(string username)
    {
        Username = username;
    }
}