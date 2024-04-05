using ConsoleTables;
using EmployeeManagementUsingEntityFramework.Models;
using EmployeeManagementUsingEntityFramework.Repositories.Implementations;
using EmployeeManagementUsingEntityFramework.Repositories.Interfaces;
using EmployeeManagementUsingEntityFramework.Services.Implementations;
using EmployeeManagementUsingEntityFramework.Services.Interfaces;
using EmployeeManagementUsingEntityFramework.Views.Enums;
using EmployeeManagementUsingEntityFramework.Views.Utilities;

namespace EmployeeManagementUsingEntityFramework.Views
{
    public class EmployeeManagement
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeManagement(IEmployeeService employeeService) 
        {
            _employeeService = employeeService;
        }

        public void EmployeeFeatures()
        {
            while (true)
            {
                Console.WriteLine("\n1.Add Employee\n2.Display All\n3.Display One\n4.Edit Employee\n5.Delete Employee\n6.Go Back\n");
              
                    int empManagementMenu = Convert.ToInt32(Console.ReadLine());
                    switch (empManagementMenu)
                    {
                        case (int)EmployeeEnum.AddEmployee:
                            AddEmployee();
                            break;
                        case (int)EmployeeEnum.DisplayEmployees:
                            DisplayEmployees();
                            break;
                        case (int)EmployeeEnum.DisplayOneEmployee:
                            DisplayOneEmployee();
                            break;
                        case (int)EmployeeEnum.UpdateEmployee:
                            UpdateEmployee();
                            break;
                        case (int)EmployeeEnum.DeleteEmployee:
                            DeleteEmployee();
                            break;
                        case (int)EmployeeEnum.GoBack:
                            return;
                        default:
                            Console.WriteLine("You have Entered An Invalid Option");
                            break;
                    
                }
              

            }
        }


        void AddEmployee()
        {
            string empId = TakeInput.ValidateInput("Employee Number", Validations.IsIdValidPattern);
            while (!Validations.IsIdUnique(empId, _employeeService))
            {
                Console.ForegroundColor=ConsoleColor.Red;
                Console.WriteLine("ID Should be unique");
                Console.ForegroundColor=ConsoleColor.White;
                Console.Write("Enter Employee Number*:");
                empId = Console.ReadLine();
                Validations.IsIdUnique(empId, _employeeService);
            }
            string firstName = TakeInput.ValidateInput("First Name*", Validations.IsNameValidPattern);
            string lastName = TakeInput.ValidateInput("Last Name*", Validations.IsNameValidPattern);
            string email = TakeInput.ValidateInput("Email*", Validations.IsEmailValid);
            DateTime? dob = TakeInput.ValidateDateInput("Date of Birth(DD/MM/YYYY format)");
            string location = TakeInput.ValidateInput("Location*", Validations.IsNameValidPattern);
            string jobTitle = TakeInput.ValidateInput("Job Title*", Validations.IsNameValidPattern);
            long? mobile = TakeInput.ValidateMobileInput("Enter Mobile Number");
            string department = TakeInput.SelectFromMenu("Choose Departments*", new StaticData().departments);
            string managerName = TakeInput.ValidateInput("Manager Name*", Validations.IsNameManagerValidPattern);
            DateTime? joinDate = TakeInput.ValidateJoinDateInput("Joining Date*(DD/MM/YYYY format)");
            string project = TakeInput.SelectFromMenu("Choose Projects*:", new StaticData().projects);
            var employee = new Employee()
                                             {
                                                EmpId= empId,
                                                FirstName = firstName,
                                                LastName = lastName,
                                                DateOfBirth = dob,
                                                Email = email,
                                                Phone = mobile,
                                                JoinDate = joinDate,
                                                Location = location,
                                                JobTitle = jobTitle,
                                                Department = department,
                                                Manager = managerName,
                                                Project = project
                                            };
            _employeeService.AddEmployee(employee);
            Console.WriteLine("Employee Added Successfully!!");

        }
        void DisplayEmployees()
        {
            Console.WriteLine("Displaying All Users");

            var table = new ConsoleTable("Emp No", "Full Name", "Department", "Location", "Joining Date", "Manager name", "Project name");
            _employeeService.GetEmployees().ForEach(emp =>
            {

                table.AddRow(emp.EmpId, emp.FirstName + " " + emp.LastName, emp.Department, emp.Location,emp.JoinDate.ToString().Substring(0,10), emp.Manager, emp.Project);
            }

            );

            Console.ForegroundColor = ConsoleColor.Green;
            table.Write();
            Console.ForegroundColor = ConsoleColor.White;

        }

        void DisplayOneEmployee()
        {
            bool isEmployeeFound = false;
            Console.WriteLine("Enter the Id of the Employee You want to Display");
            string id = Console.ReadLine();
            var table = new ConsoleTable("Emp No", "Full Name", "Department", "Location", "Joining Date", "Manager name", "Project name");
            _employeeService.GetEmployees().ForEach(emp =>
            {
                if (emp.EmpId.ToLower() == id.ToLower())

                {
                    isEmployeeFound = true;
                    table.AddRow(emp.EmpId, emp.FirstName + " " + emp.LastName, emp.Department, emp.Location, DateTime.Now.ToString().Substring(0, 10), emp.Manager, emp.Project);
                }
            });

            if (!isEmployeeFound)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Employee Not Found !!!!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                table.Write();
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        void UpdateEmployee()
        {
            Console.WriteLine("Enter the Employee ID you want to Update");
            bool isEmployeeFound = false;
            string? idToBeUpdated = Console.ReadLine();
            _employeeService.GetEmployees().ForEach(emp =>
            {
                if (emp.EmpId.ToLower() == idToBeUpdated.ToLower())
                {
                    isEmployeeFound = true;
                    string firstName = TakeInput.ValidateInput("First Name*", Validations.IsNameValidPattern);
                    string lastName = TakeInput.ValidateInput("Last Name*", Validations.IsNameValidPattern);
                    string email = TakeInput.ValidateInput("Email", Validations.IsEmailValid);
                    DateTime? dob = TakeInput.ValidateDateInput("Date of Birth(DD/MM/YYYY format)");
                    string location = TakeInput.ValidateInput("Location*", Validations.IsNameValidPattern);
                    string jobTitle = TakeInput.ValidateInput("Job Title*", Validations.IsNameValidPattern);
                    long? mobile = TakeInput.ValidateMobileInput("Enter Mobile Number");
                    string department = TakeInput.SelectFromMenu("Choose Departments*", new StaticData().departments);
                    Console.Write("Enter Manager Name");
                    string managerName = Console.ReadLine();
                    DateTime? joinDate = TakeInput.ValidateJoinDateInput("Joining Date(DD/MM/YYYY format)*");
                    string project = TakeInput.SelectFromMenu("Choose Projects:", new StaticData().projects);
                    var employee = new Employee()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        DateOfBirth = dob,
                        Email = email,
                        Phone = mobile,
                        JoinDate = joinDate,
                        Location = location,
                        JobTitle = jobTitle,
                        Department = department,
                        Manager = managerName,
                        Project = project
                    };
                    _employeeService.UpdateEmployee(idToBeUpdated,employee);

                }
            });
            if (!isEmployeeFound)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Employee Not Found !!!!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Updated Successfully");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        void DeleteEmployee()
        {
            Console.WriteLine("Enter Employee ID you want to delete");
            bool isEmployeeFound = false;
            string idToBeDeleted = Console.ReadLine();
            _employeeService.GetEmployees().ForEach(emp =>
            {
                if (emp.EmpId.ToLower() == idToBeDeleted.ToLower())
                {
                    isEmployeeFound = true;
                    _employeeService.DeleteEmployee(idToBeDeleted);
                }
            });
            if (!isEmployeeFound)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Employee Not Found");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Deleted Successfully");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }



    }
}
