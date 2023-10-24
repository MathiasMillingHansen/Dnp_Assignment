namespace BlazorApp.LoginModels;

public class LoginUser
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    
    public LoginUser(string userName, string password, string role)
    {
        UserName = userName;
        Password = password;
        Role = role;
    }
}