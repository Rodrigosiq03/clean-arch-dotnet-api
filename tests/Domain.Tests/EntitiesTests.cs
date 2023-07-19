using Domain.Entities;
using Domain.Enums;
using Domain.Errors;

namespace Domain.Tests;

public class EntitiesTests
{
    [Fact]
    public void UserEntityTestSuccess()
    {
        User user = new("22.00680-0", "Rodrigo Diana Siqueira", "22.00680-0@maua.br", State.Pending);

        Assert.IsType<User>(user);
        Assert.True(User.ValidateEmail(user.Email));
    }
    [Fact]
    public void UserEntityTestRaError()
    {
        var error = Assert.Throws<EntityError>(() => new User("", "Rodrigo Diana Siqueira", "22.00680-0@maua.br", State.Pending));

        Assert.Throws<EntityError>(() => new User("", "Rodrigo Diana Siqueira", "22.00680-0@maua.br", State.Pending));
        Assert.Equal("Field this.Ra is not valid", error.Message);
    }
    [Fact]
    public void UserEntityTestNameError()
    {

        var error = Assert.Throws<EntityError>(() => new User("22.00680-0", "", "22.00680-0@maua.br", State.Pending));

        Assert.Throws<EntityError>(() => new User("22.00680-0", "", "22.00680-0@maua.br", State.Pending));
        Assert.Equal("Field this.Name is not valid", error.Message);
    }
    [Fact]
    public void UserEntityTestEmailError()
    {

        var error = Assert.Throws<EntityError>(() => new User("22.00680-0", "Rodrigo Diana Siqueira", "", State.Pending));

        Assert.Throws<EntityError>(() => new User("22.00680-0", "Rodrigo Diana Siqueira", "", State.Pending));
        Assert.Equal("Field this.Email is not valid", error.Message);
    }
}