using System.Net.Http.Json;
using Clients.ClientInterfaces;
using Shared.DTOs.RedditPost;

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
}