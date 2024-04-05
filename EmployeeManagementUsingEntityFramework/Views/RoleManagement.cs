using ConsoleTables;
using EmployeeManagementUsingEntityFramework.Services.Implementations;
using EmployeeManagementUsingEntityFramework.Services.Interfaces;
using EmployeeManagementUsingEntityFramework.Views.Enums;
using EmployeeManagementUsingEntityFramework.Views.Utilities;

namespace EmployeeManagementUsingEntityFramework.Views
{
    public class RoleManagement
    {
        private readonly IRoleService _roleService;
        public RoleManagement(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public void RoleFeatures()
        {
            while (true)
            {
                Console.WriteLine("1.Add Role\n2.Display All\n3.Go Back");
                int roleManagementMenu = Convert.ToInt32(Console.ReadLine());
                switch (roleManagementMenu)
                {
                    case (int)RoleEnum.AddRole:
                        AddRole();
                        break;
                    case (int)RoleEnum.DisplayRole:
                        DisplayRole();
                        break;
                    case (int)RoleEnum.GoBack:
                        Console.WriteLine("Go Back");
                        return;

                }

            }


        }
        public void AddRole()
        {
            string roleName = TakeInput.ValidateInput("Role Name*", Validations.IsNameValidPattern);
            string department = TakeInput.ValidateInput("Department*", Validations.IsNameValidPattern);
            Console.Write("Description:");
            string description = Console.ReadLine();
            string location = TakeInput.ValidateInput("Location*", Validations.IsNameValidPattern);
            _roleService.AddRole(roleName, department, description, location);
        }
        public void DisplayRole()
        {
            Console.WriteLine("Displaying All Roles");
            var table = new ConsoleTable("Name", "Description", "Department", "Location");
            _roleService.GetRoles().ForEach(roles =>
            {
                table.AddRow(roles.Name, roles.Description, roles.Description, roles.Location);
            });
            table.Write();
        }

    }
}
