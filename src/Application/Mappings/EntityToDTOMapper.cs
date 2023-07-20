using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class EntityToDTOMapper : Profile
{
    public EntityToDTOMapper()
    {
        CreateMap<User, UserDTO>().ReverseMap();
    }
}

