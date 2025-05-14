using System;

namespace Blog.App.API.Entities;

public class Comment
{
    public int Id { get; set; }
    public required string Content { get; set; }

    // Comment can have 1 post
    public int PostId { get; set; }
    public Post? Post { get; set; }
}
