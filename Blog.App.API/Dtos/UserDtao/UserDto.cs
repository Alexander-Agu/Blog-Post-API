using System.ComponentModel.DataAnnotations;

namespace Blog.App.API.Dtos.UserDtao;

public record class UserDto(
    [Required][StringLength(20)] string Firstname,
    [Required][StringLength(20)] string Lastname,
    int UserId
);