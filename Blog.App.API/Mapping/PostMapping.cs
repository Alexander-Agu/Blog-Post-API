using System;
using Blog.App.API.Dtos.PostDto;
using Blog.App.API.Entities;

namespace Blog.App.API.Mapping;

public static class PostMapping
{
    public static Post ToEntity(this CreatePost createPost)
    {
        return new()
        {
            UserId = createPost.UserId,
            Title = createPost.Title,
            Content = createPost.Content
        };
    }
    public static Post ToEntity(this UpdatePost updatePost, int UserId)
    {
        return new()
        {
            UserId = UserId,
            Title = updatePost.Title,
            Content = updatePost.Content
        };
    }

    public static PostDto ToDto(this Post post)
    {
        return new(
            UserId: post.UserId,
            Title: post.Title,
            Content: post.Content
        );
    }
}
