using EmployeeManagementUsingEntityFramework;
using EmployeeManagementUsingEntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
       
        [HttpGet]
        public async Task<ActionResult<Employee>> Get()
        {
            using (var context = new EmployeeDbContext())
            {
                
                var employees =await context.Employees.ToListAsync();
                return Ok(employees);
            }
        }
        [HttpGet("id")]
        public async Task<ActionResult<Employee>> Get(string id)
        {
            using (var context = new EmployeeDbContext())
            {
                var emp = await context.Employees.FirstOrDefaultAsync(x => x.EmpId == id);
                if (emp == null)
                {
                    return NotFound();
                }
                return Ok(emp);

            }
        }

        [HttpDelete("id")]
        public async Task<ActionResult<Employee>> Delete(string id)
        {
            using (var context = new EmployeeDbContext())
            {
                var emp =await context.Employees.FirstOrDefaultAsync(x => x.EmpId == id);
                if (emp == null)
                {
                    return NotFound();
                }
                else
                {
                    context.Employees.Remove(emp);
                    context.SaveChanges();
                }

            }
            return Ok("Deleted");
        }


        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee emp)
        {
            if (emp == null)
            {
                return BadRequest();
            }
            using (var context = new EmployeeDbContext())
            {
              await context.Employees.AddAsync(emp);
                context.SaveChanges();
            }

            return Ok(emp);
        }

        [HttpPut("id")]
        public async Task<ActionResult<Employee>> Put(Employee emp, string id)
        {

            using (var context = new EmployeeDbContext())
            {
                var employee =await  context.Employees.FirstOrDefaultAsync(x => x.EmpId == id);
                if (employee == null) { return NotFound(); }
                employee.FirstName = emp.FirstName;
                employee.LastName = emp.LastName;
                employee.Location = emp.Location;
                employee.Project = emp.Project;
                employee.JoinDate = emp.JoinDate;
                employee.Email = emp.Email;
                employee.Phone = emp.Phone;
                employee.Manager = emp.Manager;
                context.Employees.Update(employee);
                context.SaveChanges();
            }
            return Ok(emp);
        }


    }
}
