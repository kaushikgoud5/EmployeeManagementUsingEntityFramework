using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementUsingEntityFramework.Models;

namespace EmployeeManagementUsingEntityFramework.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        void AddRole(Role role);
        List<Role> Get();
    }
}
