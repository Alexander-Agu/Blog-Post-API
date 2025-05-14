using System;
using Blog.App.API.Dtos.UserDtao;
using Blog.App.API.Entities;

namespace Blog.App.API.Mapping;

public static class UserMapping
{
    public static User ToEntity(CreateUser createUser)
    {
        return new()
        {
            Firstname = createUser.Firstname,
            Lastname = createUser.Lastname,
            Email = createUser.Email,
            Password = createUser.Password
        };
    }

    public static UserDto ToDto(User user)
    {
        return new(
            Firstname: user.Firstname,
            Lastname: user.Lastname,
            UserId: user.Id
        );
    }

}
