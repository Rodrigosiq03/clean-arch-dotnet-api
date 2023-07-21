using Domain.Entities;
using Domain.Enums;
using Domain.Errors;
using Domain.IRepositories;
using Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class UserRepositoryMock : IUserRepository
{
    private List<User> _users = new List<User>()
    {
        new User("22.00680-0", "Rodrigo Diana Siqueira", "rodrigo.dsiqueira@gmail.com", State.Pending),
        new User("22.00680-0", "Rodrigo Diana Siqueira", "rodrigo.dsiqueira@gmail.com", State.Pending),
        new User("22.00680-0", "Rodrigo Diana Siqueira", "rodrigo.dsiqueira@gmail.com", State.Pending),
        new User("22.00680-0", "Rodrigo Diana Siqueira", "rodrigo.dsiqueira@gmail.com", State.Pending),
        new User("22.00680-0", "Rodrigo Diana Siqueira", "rodrigo.dsiqueira@gmail.com", State.Pending),
        new User("22.00680-0", "Rodrigo Diana Siqueira", "rodrigo.dsiqueira@gmail.com", State.Pending)
    };

    public async Task<User> AddUser(User user)
    {
        _users.Add(user);
        return user;
    }

    public async Task<User> UpdateUser(string ra)
    {
        var user = _users.FirstOrDefault(user => user.Ra == ra)!;
        return user;
    }

    public async Task<User> DeleteUser(string ra)
    {
        var user = _users.FirstOrDefault(user => user.Ra == ra)!;
        if (user == null)
        {
            throw new ApplicationError(ra);
        }

        _users.Remove(user);

        return user;

    }

    public async Task<User> GetUserByRa(string ra)
    {
        var user = _users.FirstOrDefault(user => user.Ra == ra)!;
        if (user == null)
        {
            throw new ApplicationError(ra);
        }

        return user;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        var users = _users.Select(user => user);
        return users;
    }
}