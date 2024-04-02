using EmployeeManagementUsingEntityFramework.Models;


namespace EmployeeManagementUsingEntityFramework.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> Get();
        void Add(Employee employee);
        void Delete(string employeeId);

        void Update(string idTobeUpdated, Employee employee);



    }
}
