using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;
using Application.LogicInterfaces;
using Shared.DTOs.User;
using Shared.Models;

namespace WebAPI.Services;

public class AuthService : IAuthService
{
    private ICollection<User> users;
    
    private readonly HttpClient _client;

    public AuthService(HttpClient client)
    {
        _client = client;
        users = LoadUsers().Result;
    }

    

    private async Task<ICollection<User>> LoadUsers()
    {
        HttpResponseMessage response = await _client.GetAsync("User");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        ICollection<User> temp = JsonSerializer.Deserialize<ICollection<User>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return await Task.FromResult(temp);
    }

    public Task<User> GetUser(string username, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<User> RegisterUser(User user)
    {
        if (string.IsNullOrEmpty(user.Username))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        // Do more user info validation here

        // save to persistence instead of list

        HttpResponseMessage response = await _client.PostAsJsonAsync("User", user);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        User newUser = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return newUser;
    }

    public Task<User> ValidateTheUser(GetUserWithPasswordDto user)
    {
        User? existingUser = users.FirstOrDefault(u =>
            u.Username.Equals(user.Username, StringComparison.OrdinalIgnoreCase));

        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        return Task.FromResult(existingUser);
    }
}