using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TextApp.Domain.Roles
{
    public interface IRoleRepository
    {
        Task CreateRole(string RoleName);
        Task<bool> CheckIfRoleExist(string RoleName);
    }
}
