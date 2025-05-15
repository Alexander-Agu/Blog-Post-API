using System.ComponentModel.DataAnnotations;

namespace Blog.App.API.Dtos.CommentDto;

public record class CommentDto(
    [Required] int Id,
    [Required] int PostId,
    [Required] string Title,
    [Required] string Content
);