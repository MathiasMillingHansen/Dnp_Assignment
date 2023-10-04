using System.Net.Http.Json;
using System.Text.Json;
using Clients.ClientInterfaces;
using Shared.DTOs.RedditPost;
using Shared.Models;

namespace Clients.Implementations;

public class RedditPostHttpClient : IRedditPostService
{
    
    private readonly HttpClient _client;
    
    public RedditPostHttpClient(HttpClient client)
    {
        this._client = client;
    }
    
    public async Task CreatePostAsync(RedditPostCreationDto postToCreate)
    {
        HttpResponseMessage response = await _client.PostAsJsonAsync("/RedditPost",postToCreate);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<ICollection<RedditPost>> GetPostsAsync(string? owner, string? title, string? id)
    {
        HttpResponseMessage response = await _client.GetAsync("/RedditPost");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        return JsonSerializer.Deserialize<ICollection<RedditPost>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }
}