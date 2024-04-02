﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementUsingEntityFramework.Repositories;

namespace EmployeeManagementUsingEntityFramework.Models
{
    public class Employee
    {
        [Key]
        public string? EmpId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public long Phone { get; set; }

        public DateTime JoinDate { get; set; }


        public string? Location { get; set; }

        public string? JobTitle { get; set; }

        public string? Department { get; set; }
        public string? Manager { get; set; }

        public string? Project { get; set; }

    }
}
