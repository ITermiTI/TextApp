using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TextApp.Domain.Roles
{
    public class RoleRepository : IRoleRepository
    {
        public RoleManager<IdentityRole> RoleManager { get; }
        public UserManager<Infrastructure.Users.User> UserManager { get; }
        public RoleRepository(RoleManager<IdentityRole> roleManager, UserManager<Infrastructure.Users.User> userManager)
        {
            RoleManager = roleManager;
            UserManager = userManager;
        }
        public async Task CreateRole(string RoleName)
        {
            var checkIfExist = await CheckIfRoleExist(RoleName);
            if (!checkIfExist)
            {
                await RoleManager.CreateAsync(new IdentityRole(RoleName));
            };
        }

        public async Task<bool> CheckIfRoleExist(string RoleName)
        {
            return await RoleManager.RoleExistsAsync(RoleName);
        }
    }
}
