using EmployeeManagementUsingEntityFramework.Models;
using EmployeeManagementUsingEntityFramework.Repositories;
using EmployeeManagementUsingEntityFramework.Repositories.Implementations;
using EmployeeManagementUsingEntityFramework.Repositories.Interfaces;
using EmployeeManagementUsingEntityFramework.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeManagementUsingEntityFramework.Services.Implementations
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepositary;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepositary = employeeRepository;
        }
        public List<Employee> GetEmployees()
        {
            return _employeeRepositary.Get();
        }

        public void DeleteEmployee(string idToBeDeleted)
        {
            _employeeRepositary.Delete(idToBeDeleted);
        }

        public void UpdateEmployee(string id,Employee employee)
        {

            _employeeRepositary.Update(id,employee);
        }
        public void AddEmployee(Employee employee)
        {
            _employeeRepositary.Add(employee);
        }
    }
}
