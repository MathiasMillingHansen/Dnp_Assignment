using System.Text.Json;
using FileData;
using Shared.Models;

namespace FileContext;

public class FileContext
{
    private const string UserFilePath = "users.json";
    private const string PostFilePath = "posts.json";
    private UserContainer? _userContainer;
    private PostContainer? _postContainer;

    public ICollection<RedditPost?> Posts
    {
        get
        {
            LoadPosts();
            if (_postContainer.Posts == null)
            {
                _postContainer.Posts = new List<RedditPost>();
            }
            return _postContainer!.Posts!;
        }
    }

    public ICollection<User> Users
    {
        get
        {
            LoadUsers();
            return _userContainer!.Users;
        }
    }

    private void LoadUsers()
    {
        if (_userContainer != null) return;

        if (!File.Exists(UserFilePath))
        {
            _userContainer = new()
            {
                Users = new List<User>()
            };
            return;
        }

        string users = File.ReadAllText(UserFilePath);
        _userContainer = JsonSerializer.Deserialize<UserContainer>(users);
    }

    private void LoadPosts()
    {
        if (_postContainer != null) return;

        if (!File.Exists(PostFilePath))
        {
            _postContainer = new()
            {
                Posts = new List<RedditPost>()
            };
            return;
        }

        string posts = File.ReadAllText(PostFilePath);
        _postContainer = JsonSerializer.Deserialize<PostContainer>(posts);
    }

    public void SaveChanges()
    {
        string usersSerialized = JsonSerializer.Serialize(_userContainer);
        string postsSerialized = JsonSerializer.Serialize(_postContainer);
        
        File.WriteAllText(UserFilePath, usersSerialized);
        File.WriteAllText(PostFilePath, postsSerialized);

        _userContainer = null;
        _postContainer = null;
    }
    
    

}