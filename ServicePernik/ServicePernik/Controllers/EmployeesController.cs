using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Authorize]
    public class EmployeesController : Controller
    {

        private readonly UserManager<ServiceUser> _userManager;
        private readonly IEmployeeService _employeeService;
        private readonly ApplicationDbContext _context;

        public EmployeesController(UserManager<ServiceUser> userManager, IEmployeeService employeeService, ApplicationDbContext context)
        {
            _userManager = userManager;                                                      
            _employeeService = employeeService;
            _context = context;
        }

        //public EmployeesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: EmployeesController
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            var users = _employeeService.GetEmployees()
                  .Select(u => new EmployeeListingVM
                  {
                      Id = u.Id,
                      FirstName = u.FirstName,
                      LastName = u.LastName,
                      Email = u.User.Email,
                      PhoneNumber = u.User.PhoneNumber,
                      JobTitle = u.JobTitle
                  }).ToList();

            return this.View(users);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            Employee item = _employeeService.GetEmployeeById(id);
            if (item == null)
            {
                return NotFound();
            }
            EmployeeDetailsVM employee = new EmployeeDetailsVM()
            {
                Id = item.Id,
                UserName = item.User.UserName,
                Email = item.User.Email,
                PhoneNumber = item.User.PhoneNumber,
                FirstName = item.FirstName,
                LastName = item.LastName,
                JobTitle = item.JobTitle
            };
            return View(employee);
        }

        // GET: EmployeesController/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
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
                user.PhoneNumber = employee.PhoneNumber;

                var result = await _userManager.CreateAsync(user, "Employee123!");

                if (result.Succeeded)
                {
                    var created = _employeeService.CreateEmployee(employee.FirstName, employee.LastName,  employee.JobTitle, user.Id);
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
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            Employee item = _employeeService.GetEmployeeById(id);
            if (item == null)
            {
                return NotFound();
            }
            CreateEmployeeVM employee = new CreateEmployeeVM()
            {
                Id = item.Id,
                Username = item.User.UserName,
                Email = item.User.Email,
                PhoneNumber = item.User.PhoneNumber,
                FirstName = item.FirstName,
                LastName = item.LastName,
                JobTitle = item.JobTitle,
            };
            return View(employee);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id, CreateEmployeeVM bindingModel)
        {
            if (ModelState.IsValid)
            {
                var updated = _employeeService.UpdateEmployee(id, bindingModel.Username, bindingModel.Email, bindingModel.PhoneNumber, bindingModel.FirstName, bindingModel.LastName, bindingModel.JobTitle);
                if (updated)
                {
                    return this.RedirectToAction("Index");
                }

            }
            return View(bindingModel);

        }

        // GET: EmployeesController/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            Employee item = _employeeService.GetEmployeeById(id);
            if (item == null)
            {
                return NotFound();
            }
            CreateEmployeeVM employee = new CreateEmployeeVM()
            {
                Id = item.Id,
                Username = item.User.UserName,
                Email = item.User.Email,
                PhoneNumber = item.User.PhoneNumber,
                FirstName = item.FirstName,
                LastName = item.LastName,
                JobTitle = item.JobTitle,
            };
            return View(employee);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _employeeService.RemoveById(id);

            if (deleted)
            {
                return this.RedirectToAction("Index", "Employees");
            }
            else
            {
                return View();
            }

        }
        public IActionResult Success()
        {
            return this.View();

        }
    }
}
