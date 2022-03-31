﻿using ServicePernik.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePernik.Abstractions
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();

        Employee GetEmployeeById(int employeeId);
        List<Hour> GetHoursByEmployee(int empoyeeId);
        List<Repair> GetRepairsByEmployee(int employeeId);

        public bool RemoveById(int employeeId);

        string GetFullName(int employeeId);

        bool CreateEmployee(string firstName, string lastName, string jobTitle, string userId);
    }
}
