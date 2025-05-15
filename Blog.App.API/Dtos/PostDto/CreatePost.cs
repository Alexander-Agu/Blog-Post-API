using System.ComponentModel.DataAnnotations;

namespace Blog.App.API.Dtos.PostDto;

public record class CreatePost(
    [Required] int UserId,
    [Required] string Title,
    [Required] string Content
);
