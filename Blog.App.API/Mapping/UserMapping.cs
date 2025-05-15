using System;
using Blog.App.API.Dtos.UserDtao;
using Blog.App.API.Entities;

namespace Blog.App.API.Mapping;

public static class UserMapping
{
    public static User ToEntity(this CreateUser createUser)
    {
        return new()
        {
            Firstname = createUser.Firstname,
            Lastname = createUser.Lastname,
            Email = createUser.Email,
            Password = createUser.Password
        };
    }

    public static User ToEntity(this UpdateUser updateUser)
    {
        return new()
        {
            Firstname = updateUser.Firstname,
            Lastname = updateUser.Lastname,
            Email = updateUser.Email,
            Password = updateUser.Password
        };
    }

    public static UserDto ToDto(this User user)
    {
        return new(
            Firstname: user.Firstname,
            Lastname: user.Lastname,
            UserId: user.Id
        );
    }

}
