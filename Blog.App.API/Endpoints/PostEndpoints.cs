using System;
using Blog.App.API.Data;
using Blog.App.API.Dtos.PostDto;
using Blog.App.API.Entities;
using Blog.App.API.Mapping;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Blog.App.API.Endpoints;

public static class PostEndpoints
{
    public static RouteGroupBuilder MapPostEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/blog/post");
        string postEndpoint = "GetPost";


        // GET - get all user posts
        group.MapGet("/{userId}", async (int userId, BlogAppContext dbContext) =>
        {
            List<PostDto> posts = await dbContext.Posts.Where(x => x.UserId == userId)
            .Select(post => new PostDto
            (
                post.UserId,
                post.Title,
                post.Content
            ))
            .ToListAsync();

            return Results.Ok(posts);
        });


        // GET - get post by userId and postId
        group.MapGet("/{userId}/{postId}", async (int userId, int postId, BlogAppContext dbContext) =>
        {
            Post? post = dbContext.Posts.Where(x => x.UserId == userId && x.Id == postId).FirstOrDefault();

            return post is null ? Results.NotFound() : Results.Ok(post.ToDto());
        })
        .WithName(postEndpoint);


        // POST - creates posts
        group.MapPost("/{id}", async (int id, CreatePost createPost, BlogAppContext dbContext) =>
        {
            User? user = await dbContext.Users.FindAsync(id);
            if (user is null) return Results.NotFound();


            Post post = createPost.ToEntity();
            post.User = user;


            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(postEndpoint, new { userId = id, postId = post.Id }, post.ToDto());
        });


        // PUT - update user posts
        group.MapPut("/{userId}/{postId}", async (int userId, int postId, UpdatePost updatePost, BlogAppContext dbContext) =>
        {
            Post? post = await dbContext.Posts.Where(x => x.UserId == userId && x.Id == postId).FirstOrDefaultAsync();
            if (post is null) return Results.NotFound();

            if (updatePost.Title != "") post.Title = updatePost.Title;
            if (updatePost.Content != "") post.Content = updatePost.Content;

            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(postEndpoint, new { userId = post.UserId, postId = post.Id }, post.ToDto());

        });




        return group;
    }
}
