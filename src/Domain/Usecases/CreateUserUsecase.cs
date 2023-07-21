using Domain.IRepositories;

namespace Domain.Usecases;

public class CreateUserUsecase
{
    private readonly IUserRepository _repository;

    public CreateUserUsecase(IUserRepository repo)
    {
        _repository = repo;
    }

    public async Task<UserDTO> Execute(UserDTO userDto)
    {
        if (userDto)
    }
}



