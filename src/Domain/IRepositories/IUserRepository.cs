using Domain.Entities;

namespace Domain.IRepositories;

public interface IUserRepository
{
    Task<User> AddUser(User user);
    Task<User> UpdateUser(User user);
    Task<User> DeleteUser(string ra);
    Task<User> GetUserByRa(string ra);
    Task<IEnumerable<User>> GetAllUsers();
}
