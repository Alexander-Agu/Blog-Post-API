using System.ComponentModel.DataAnnotations;

namespace Blog.App.API.Dtos.PostDto;

public record class UpdatePost(
    [Required] string Title,
    [Required] string Content
);