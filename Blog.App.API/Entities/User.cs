using System;
using System.Collections;

namespace Blog.App.API.Entities;

public class User
{
    public int Id { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }

    // User can have many posts
    public List<Post>? Posts { get; set; }
}
