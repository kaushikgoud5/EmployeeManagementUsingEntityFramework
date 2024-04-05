using EmployeeManagementUsingEntityFramework.Models;

namespace EmployeeManagementUsingEntityFramework.Services.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        void DeleteEmployee(string idToBeDeleted);
        void UpdateEmployee(string id,Employee employee);
        void AddEmployee(Employee employee);
    }
}
