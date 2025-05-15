using System.ComponentModel.DataAnnotations;

namespace Blog.App.API.Dtos.PostDto;

public record class PostDto(
    [Required] int UserId,
    [Required] string Title,
    [Required] string Content
);