using Application.DTO;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class AutoMapperConfiguration
    {
        public static IMapper Initialize()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Note, NoteDto>();
                cfg.CreateMap<CreateNoteDto, Note>();
                cfg.CreateMap<UpdateNoteDto, Note>();
                cfg.CreateMap<CreateUserDto, User>();
            }).CreateMapper();
        }
    }
}
