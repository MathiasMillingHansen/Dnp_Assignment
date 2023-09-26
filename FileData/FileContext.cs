using System.Text.Json;
using Shared.Models;

namespace FileContext;

public class FileContext
{
    private const string UserFilePath = "users.json";
    private const string PostFilePath = "posts.json";
    private UserContainer? UserContainer;
    private PostContainer? PostContainer;

    public ICollection<RedditPost> Posts
    {
        get
        {
            LoadPosts();
            return PostContainer!.Posts;
        }
    }

    public ICollection<User> Users
    {
        get
        {
            LoadUsers();
            return UserContainer!.Users;
        }
    }

    private void LoadUsers()
    {
        if (UserContainer != null) return;

        if (!File.Exists(UserFilePath))
        {
            UserContainer = new()
            {
                Users = new List<User>()
            };
            return;
        }

        string users = File.ReadAllText(UserFilePath);
        UserContainer = JsonSerializer.Deserialize<UserContainer>(users);
    }

    private void LoadPosts()
    {
        if (PostContainer != null) return;

        if (!File.Exists(PostFilePath))
        {
            PostContainer = new()
            {
                Posts = new List<Post>()
            };
            return;
        }

        string posts = File.ReadAllText(PostFilePath);
        PostContainer = JsonSerializer.Deserialize<PostContainer>(posts);
    }

}