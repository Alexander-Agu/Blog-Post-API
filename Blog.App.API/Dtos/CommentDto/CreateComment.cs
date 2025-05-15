using System.ComponentModel.DataAnnotations;

namespace Blog.App.API.Dtos.CommentDto;

public record class CreateComment(
    [Required][StringLength(20)] string Title,
    [Required] string Content
);
