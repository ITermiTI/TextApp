using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TextApp.Presentation.User
{
    public interface IUserPresentationRepository
    {
        Task<bool> Login(UserDto userDto);
        Task<bool> Register(UserDto userDto, bool ShouldBeAdmin);

        Task Logout();
    }
}
