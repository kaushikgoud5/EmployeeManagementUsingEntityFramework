// See https://aka.ms/new-console-template for more information
using EmployeeManagementUsingEntityFramework;
using EmployeeManagementUsingEntityFramework.Repositories.Implementations;
using EmployeeManagementUsingEntityFramework.Repositories.Interfaces;
using EmployeeManagementUsingEntityFramework.Services.Implementations;
using EmployeeManagementUsingEntityFramework.Services.Interfaces;
using EmployeeManagementUsingEntityFramework.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
serviceCollection.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=employeeDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));
serviceCollection.AddTransient<IEmployeeService, EmployeeService>();
serviceCollection.AddTransient<IEmployeeRepository, EmployeeRepository>();
serviceCollection.AddTransient<IRoleService, RolesService>();
serviceCollection.AddTransient<IRoleRepository, RoleRepository>();
var service = serviceCollection.BuildServiceProvider();
var employeeService = service.GetService<IEmployeeService>();
var roleService = service.GetRequiredService<IRoleService>();




Console.WriteLine("Employee Management System");
while (true)
{
    try
    {
        Console.WriteLine("1.Employee Management\n2.Role Management\n3.Exit\n");
        int mainMenuOption = Convert.ToInt32(Console.ReadLine());
        switch (mainMenuOption)
        {
            case 1:
                EmployeeManagement employeeManagement = new EmployeeManagement(employeeService);
                employeeManagement.EmployeeFeatures();
                break;
            case 2:
                RoleManagement roleManagement = new RoleManagement(roleService);
                roleManagement.RoleFeatures();
                break;
            case 3:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("You have Entered An Invalid Option");
                break;
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine();
    }

}
