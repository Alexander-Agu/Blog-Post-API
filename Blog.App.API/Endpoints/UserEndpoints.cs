using System;
using Blog.App.API.Data;
using Blog.App.API.Dtos.UserDtao;
using Blog.App.API.Entities;
using Blog.App.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Blog.App.API.Endpoints;

public static class UserEndpoints
{
    public static RouteGroupBuilder MapUserEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("blog/user").WithParameterValidation();
        string getUserEndpoint = "GetUser";


        // GET - gets all users
        group.MapGet("/", async (BlogAppContext dbContext) => await dbContext.Users.ToListAsync());


        // GET - gets user by ID
        group.MapGet("/{id}", async (int id, BlogAppContext dbContext) =>
        {
            User? user = await dbContext.Users.FindAsync(id);

            return user is null ? Results.NotFound() : Results.Ok(user.ToDto());
        })
        .WithName(getUserEndpoint);


        // POST - creates a new user
        group.MapPost("/", async (CreateUser createUser, BlogAppContext dbContext) =>
        {
            User? user = createUser.ToEntity();

            // Checks if email already exists within the DB
            bool emailExist = await dbContext.Users.AnyAsync(x => x.Email == createUser.Email);
            if (emailExist) return Results.Conflict(new { message = "Email already exists!" });

            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(getUserEndpoint, new { id = user.Id }, user.ToDto());
        })
        .WithParameterValidation();

        return group;
    }
}
