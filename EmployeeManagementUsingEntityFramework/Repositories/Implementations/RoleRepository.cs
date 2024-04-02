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
        public void AddRole(Role role)
        {
            using(var context=new EmployeeDbContext())
            {
                context.Roles.Add(role);
                context.SaveChanges();
            }
        }
        public List<Role> Get()
        {
            var roles = new List<Role>();
            using (var context = new EmployeeDbContext())
            {
                roles =context.Roles.ToList();
            }
            return roles;

        }
    }
}
