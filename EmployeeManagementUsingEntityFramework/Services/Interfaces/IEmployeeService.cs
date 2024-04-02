using EmployeeManagementUsingEntityFramework.Models;

namespace EmployeeManagementUsingEntityFramework.Services.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        void DeleteEmployee(string idToBeDeleted);
        void UpdateEmployee(string idToBeUpdated, string firstName, string lastName, DateTime dob, string email, long mobile, DateTime date, string location, string jobTitle, string department, string managerName, string project);
        void AddEmployee(string empId, string firstName, string lastName, DateTime dob, string email, long mobile, DateTime date, string location, string jobTitle, string department, string managerName, string project);
    }
}
