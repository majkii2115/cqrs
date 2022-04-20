using AutoMapper;
using cqrs.Domain;
using cqrs.DTOs;

namespace cqrs.Helpers;
public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AddTodoDto, Todo>();
        CreateMap<UpdateTodoDto, Todo>();
    }
}