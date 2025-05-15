using System.ComponentModel.DataAnnotations;

namespace Blog.App.API.Dtos.UserDtao;

public record class UpdateUser(
    [Required][StringLength(20)] string Firstname,
    [Required][StringLength(20)] string Lastname,
    [Required][StringLength(30)] string Email,
    [Required][StringLength(50)] string Password
);