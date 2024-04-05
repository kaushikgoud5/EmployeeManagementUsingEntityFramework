using EmployeeManagementUsingEntityFramework.Models;
using EmployeeManagementUsingEntityFramework.Services.Interfaces;
using System.Text.RegularExpressions;

namespace EmployeeManagementUsingEntityFramework.Views.Utilities
{
    public class Validations
    {
        public static bool IsIdValidPattern(string empId)
        {
            string pattern = @"^TZ\d{4}$";
            if (Regex.IsMatch(empId, pattern)) return true;
            return false;
        }
        public static bool IsNameValidPattern(string name)
        {
            string pattern = @"[a-zA-Z]+$";
            if (Regex.IsMatch(name, pattern)) return true;
            return false;
        }
        public static bool IsNameManagerValidPattern(string name)
        {
            if(string.IsNullOrWhiteSpace(name)) return true; 
            string pattern = @"[a-zA-Z]+$";
            if (Regex.IsMatch(name, pattern)) return true;
            return false;
        }
        public static bool IsEmailValid(string email)
        {
      
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (Regex.IsMatch(email, pattern)) return true;
            return false;
        }
        public static bool IsIdUnique(string? empId, IEmployeeService employeeService)
        {
            List<Employee> list = employeeService.GetEmployees();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].EmpId == empId) return false;
            }
            return true;
        }



    }
}
