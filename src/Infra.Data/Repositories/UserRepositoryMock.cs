using Domain.Entities;
using Domain.Errors;
using Domain.IRepositories;
using Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class UserRepositoryMock : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepositoryMock(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<User> AddUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUser(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> DeleteUser(string ra)
    {
        var user = await _context.Users.FindAsync(ra);
        if (user == null)
        {
            throw new ApplicationError(ra);
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return user;

    }

    public async Task<User> GetUserByRa(string ra)
    {
        var user = await _context.Users.FindAsync(ra);
        if (user == null)
        {
            throw new ApplicationError(ra);
        }
        
        return user;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        var users = await _context.Users.ToListAsync();
        return users;
    }
}