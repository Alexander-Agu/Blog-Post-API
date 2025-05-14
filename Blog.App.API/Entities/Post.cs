using System;

namespace Blog.App.API.Entities;

public class Post
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }

    // Post can have 1 post
    public int UserId { get; set; }
    public User? User { get; set; }

    // Posts can have multiple comments
    public List<Comment>? Comments { get; set; }
}
