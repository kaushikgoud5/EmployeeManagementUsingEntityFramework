using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EmployeeManagementUsingEntityFramework.Models;
using EmployeeManagementUsingEntityFramework.Repositories.Interfaces;

namespace EmployeeManagementUsingEntityFramework.Repositories.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private readonly EmployeeDbContext context;
        public RoleRepository(EmployeeDbContext employeeDbContext)
        {
            context = employeeDbContext;
        }
        public void AddRole(Role role)
        {
            context.Roles.Add(role);
            context.SaveChanges();    
        }
        public List<Role> Get()
        {
           var roles =context.Roles.ToList();
           return roles;

        }
    }
}
