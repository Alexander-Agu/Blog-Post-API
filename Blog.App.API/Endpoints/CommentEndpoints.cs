using System;
using Blog.App.API.Data;
using Blog.App.API.Dtos.CommentDto;
using Blog.App.API.Entities;
using Blog.App.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Blog.App.API.Endpoints;

public static class CommentEndpoints
{
    public static RouteGroupBuilder MapCommentEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/blog/comment");
        string commentGetEndpoint = "GetComment";


        // GET - get all posts comments by postId
        group.MapGet("/{postId}", async (int postId, BlogAppContext dbContext) =>
        {
            Post? post = await dbContext.Posts.FindAsync(postId);
            if (post is null) return Results.NotFound();

            List<CommentDto> comments = await dbContext.Comments.Where(x => x.PostId == postId)
            .Select(comment => new CommentDto(
                comment.Id,
                comment.PostId,
                comment.Content
            )).ToListAsync();

            return Results.Ok(comments);
        });


        // GET - get a comment by postId and commetId
        group.MapGet("/{postId}/{commentId}", async (int postId, int commentId, BlogAppContext dbContext) =>
        {
            Comment? comment = await dbContext.Comments.Where(x => x.PostId == postId && x.Id == commentId)
            .FirstOrDefaultAsync();

            if (comment is null) return Results.NotFound();

            return Results.Ok(comment.ToDto());
        })
        .WithName(commentGetEndpoint);


        return group;
    }
}
