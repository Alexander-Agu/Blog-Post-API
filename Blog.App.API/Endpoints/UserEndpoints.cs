using System;

namespace Blog.App.API.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("blog/user");
        group.MapGet("/", () => "Hello World!");
    }
}
