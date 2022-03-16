﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServicePernik.Abstractions;
using ServicePernik.Data;
using ServicePernik.Entities;
using ServicePernik.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePernik.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly UserManager<ServiceUser> _userManager;
        private readonly IEmployeeService _employeeService;
        private readonly ApplicationDbContext _context;

        public EmployeesController(UserManager<ServiceUser> userManager, IEmployeeService employeeService)
        {
            _userManager = userManager;
            _employeeService = employeeService;
        }

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEmployeeVM employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            if (await _userManager.FindByNameAsync
                (employee.Username) == null)
            {
                ServiceUser user = new ServiceUser();
                user.UserName = employee.Username;
                user.Email = employee.Email;

                var result = await _userManager.CreateAsync(user, "Employee123!");

                if (result.Succeeded)
                {
                    var created = _employeeService.CreateEmployee(employee.FirstName, employee.LastName, employee.Phone, employee.JobTitle, user.Id);
                    if (created)
                    {
                        _userManager.AddToRoleAsync(user, "Employee").Wait();
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "The employee exists.");
            return View();
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
