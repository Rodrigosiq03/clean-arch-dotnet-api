using Application.DTOs;

namespace Application.IServices;

public interface IUserService
{
    Task<UserDTO> AddUser(UserDTO userDto);
    Task<UserDTO> UpdateUser(UserDTO userDto);
    Task<UserDTO> DeleteUser(string ra);
    Task<UserDTO> GetUserByRa(string ra);
    Task<IEnumerable<UserDTO>> GetAllUsers();
}



