using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TextApp.Domain.Roles;
using TextApp.Infrastructure;

namespace TextApp.Domain.User
{
    public class UserRepository : IUserRepository
    {
        public SignInManager<Infrastructure.Users.User> SignInManager { get; }
        public UserManager<Infrastructure.Users.User> UserManager { get; }
        public IRoleRepository _roleRepository { get; }
        public UserRepository(SignInManager<TextApp.Infrastructure.Users.User> signInManager, UserManager<Infrastructure.Users.User> userManager, IRoleRepository roleRepository)
        {
            SignInManager = signInManager;
            UserManager = userManager;
            _roleRepository = roleRepository;
        }



        public async Task<bool> Login(UserEntity User)
        {
            var result = await SignInManager.PasswordSignInAsync(User.UserName, User.Password, false, false);
            return result.Succeeded;
        }

        public async Task Logout()
        {
            await SignInManager.SignOutAsync();
        }

        public async Task<bool> Register(UserEntity User, bool ShouldBeAdmin)
        {
            var hasher = new PasswordHasher<Infrastructure.Users.User>();
            Infrastructure.Users.User newUser = new Infrastructure.Users.User
            {

                UserName = User.UserName,
            };
            var hashedPassword = hasher.HashPassword(newUser, User.Password);
            newUser.PasswordHash = hashedPassword;
            var result = await UserManager.CreateAsync(newUser);
            if (ShouldBeAdmin)
            {
                var checkIfExists = await _roleRepository.CheckIfRoleExist("Admin");
                if (!checkIfExists) await _roleRepository.CreateRole("Admin");
                var registeredUser = await UserManager.FindByNameAsync(User.UserName);
                await UserManager.AddToRoleAsync(registeredUser, "Admin");
            }
            return result.Succeeded;
        }
    }
}
