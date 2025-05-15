using System;
using Blog.App.API.Dtos.CommentDto;
using Blog.App.API.Entities;

namespace Blog.App.API.Mapping;

public static class CommentMapping
{
    public static Comment ToEntity(this CreateComment create, int postId)
    {
        return new()
        {
            PostId = postId,
            Content = create.Content
        };
    }

    public static Comment ToEntity(this UpdateComment update, int postId)
    {
        return new()
        {
            PostId = postId,
            Content = update.Content
        };
    }

    public static CommentDto ToDto(this Comment comment)
    {
        return new(
            Id: comment.Id,
            PostId: comment.PostId,
            Content: comment.Content
        );
    }
}
