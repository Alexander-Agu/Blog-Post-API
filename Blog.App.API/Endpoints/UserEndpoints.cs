using System;
using System.Diagnostics;
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

            // Validates password
            if (!ValidatePassword(createUser.Password)) return Results.Conflict(new { message = "Create a better password!" });

            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(getUserEndpoint, new { id = user.Id }, user.ToDto());
        })
        .WithParameterValidation();

        return group;
    }

    private static bool ValidatePassword(string password)
    {
        if (password.Length < 8) return false; // Checks if password is over 8 characters


        bool number = false, special = false, lower = false, upper = false;

        for (int x = 0; x <= password.Length - 1; x++)
        {
            if (char.IsNumber(password, x)) number = true; // Checks if password has a number

            if (char.IsUpper(password, x)) upper = true; // Checks if password has an uppercase letter

            if (char.IsLower(password, x)) lower = true; // Checks if password has a lowercase letter

            if ("!@#$%^&*()_".Contains(password[x])) special = true; // Checks if password has special characters

            if (number && special && lower && upper) break; // If all these conditions have been met stop checking
        }

        if (number && special && lower && upper)
        {
            return true;
        }
        return false;
    }
}
