using Application.DTOs;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<UserDTO> AddUser(UserDTO userDto)
    {
        var user = _mapper.Map<User>(userDto);
        var userAdded = await _repository.AddUser(user);
        return _mapper.Map<UserDTO>(userAdded);
    }

    public async Task<UserDTO> UpdateUser(string ra)
    {
        var userUpdated = await _repository.UpdateUser(ra);
        return _mapper.Map<UserDTO>(userUpdated);
    }

    public async Task<UserDTO> DeleteUser(string ra)
    {
        var userDeleted = await _repository.DeleteUser(ra);
        return _mapper.Map<UserDTO>(userDeleted);
    }

    public async Task<UserDTO> GetUserByRa(string ra)
    {
        var user = await _repository.GetUserByRa(ra);
        return _mapper.Map<UserDTO>(user);
    }

    public async Task<IEnumerable<UserDTO>> GetAllUsers()
    {
        var users = await _repository.GetAllUsers();
        return _mapper.Map<IEnumerable<UserDTO>>(users);
    }
}