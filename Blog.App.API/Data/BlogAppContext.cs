using System;
using Blog.App.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.App.API.Data;

public class BlogAppContext(DbContextOptions<BlogAppContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Comment> Comments => Set<Comment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>()  // Targets the Posts entity
        .HasOne(c => c.User)  // Each post has one user
        .WithMany(x => x.Posts)  // Each user has many posts
        .HasForeignKey(j => j.UserId)  // Checks for forein key where cascade should be implemented
        .OnDelete(DeleteBehavior.Cascade);  // This just tells EF core how the relationship should behave if the parent is deleted

        modelBuilder.Entity<Comment>()
        .HasOne(i => i.Post)
        .WithMany(h => h.Comments)
        .HasForeignKey(j => j.PostId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
