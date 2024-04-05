using EmployeeManagementUsingEntityFramework.Models;
using EmployeeManagementUsingEntityFramework.Repositories;
using EmployeeManagementUsingEntityFramework.Repositories.Implementations;
using EmployeeManagementUsingEntityFramework.Repositories.Interfaces;
using EmployeeManagementUsingEntityFramework.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementUsingEntityFramework.Services.Implementations
{
    public class RolesService:IRoleService
    {
        private readonly IRoleRepository _roleRepositary;
        public RolesService(IRoleRepository roleRepository)
        {
            _roleRepositary = roleRepository;
        }

        public void AddRole(string roleName, string department, string description, string location)
        {
            var role = new Role { Department = department, Name = roleName, Description = description, Location = location };
            _roleRepositary.AddRole(role);
        }

        public List<Role> GetRoles()
        {
            return _roleRepositary.Get();
        }
    }
}
