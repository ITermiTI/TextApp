using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TextApp.Infrastructure;

namespace TextApp.Domain.User
{
    public interface IUserRepository
    {
        Task<bool> Register(UserEntity User, bool ShouldBeAdmin);

        Task<bool> Login(UserEntity User);

        Task Logout();
    }
}
