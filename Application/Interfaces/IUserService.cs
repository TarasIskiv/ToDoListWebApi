using Application.DTO;
using System.Collections.Generic;


namespace Application.Interfaces
{
    public interface IUserService
    {
        public void Create(CreateUserDto dto);

        public IEnumerable<UserDto> GetAllUsers();
    }
}
