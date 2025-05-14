using System;
using Microsoft.EntityFrameworkCore;

namespace Blog.App.API.Data;

public static class DataExtensions
{
    public async static Task MigrateAsync(this WebApplication app)
    {
        var scope = app.Services.CreateAsyncScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<BlogAppContext>();
        await dbContext.Database.MigrateAsync();
    }
}
