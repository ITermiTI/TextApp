using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TextApp.Domain.User;

namespace TextApp.Presentation.User
{
    public class UserPresentationRepository : IUserPresentationRepository
    {
        public IUserRepository UserRepository { get; }
        public UserPresentationRepository(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }



        public async Task<bool> Login(UserDto userDto)
        {
            return await UserRepository.Login(new Infrastructure.UserEntity
            {
                UserName = userDto.UserName,
                Password = userDto.Password,
            });
        }

        public async Task Logout()
        {
            await UserRepository.Logout();
        }

        public async Task<bool> Register(UserDto userDto, bool ShouldBeAdmin)
        {
            return await UserRepository.Register(new Infrastructure.UserEntity
            {
                UserName = userDto.UserName,
                Password = userDto.Password,
            }, ShouldBeAdmin);
        }
    }
}
