using EmployeeManagementUsingEntityFramework.Models;
using EmployeeManagementUsingEntityFramework.Repositories.Interfaces;

namespace EmployeeManagementUsingEntityFramework.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public void Add(Employee employee)
        {
            using (var context = new EmployeeDbContext())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }

        public void Update(string idTobeUpdated, Employee employee)
        {
            using (var context = new EmployeeDbContext())
            {
                foreach (var item in context.Employees)
                {
                    if (item.EmpId == idTobeUpdated)
                    {
                        item.FirstName = employee.FirstName;
                        item.LastName = employee.LastName;
                        item.DateOfBirth = employee.DateOfBirth;
                        item.Email = employee.Email;
                        item.JobTitle = employee.JobTitle;
                        item.JoinDate = employee.JoinDate;
                        item.Location = employee.Location;
                        item.Project = employee.Project;
                        item.Department = employee.Department;
                    }
                }
                context.SaveChanges();
            }
        }
        public List<Employee> Get()
        {
            var employees = new List<Employee>();
            using (var context = new EmployeeDbContext())
            {
                employees = context.Employees.ToList();
            }
            return employees;

        }

        public void Delete(string id)
        {
            using (var context = new EmployeeDbContext())
            {
                foreach (var item in context.Employees)
                {
                    if (item.EmpId == id)
                    {
                        context.Employees.Remove(item);
                    }
                }
                context.SaveChanges();
            }

        }

    }
}
