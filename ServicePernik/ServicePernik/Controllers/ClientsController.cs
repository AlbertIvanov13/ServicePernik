using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServicePernik.Abstractions;
using ServicePernik.Data;
using ServicePernik.Entities;
using ServicePernik.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServicePernik.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;
        private readonly ApplicationDbContext context;
        private readonly UserManager<ServiceUser> _userManager;

        public ClientsController(IClientService clientService, ApplicationDbContext context, UserManager<ServiceUser> userManager)
        {
            _clientService = clientService;
            this.context = context;
            _userManager = userManager;
        }
        // GET: ClientsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClientsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateClientVM client)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userIdAlreadyClient = this._clientService
                .GetClients()
                .Any(d => d.UserId == userId);
            if (!ModelState.IsValid)
            {
                return View(client);
            }
            var created = _clientService.CreateClient(client.FirstName, client.LastName, client.Address, userId);

            if (created)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        // GET: ClientsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientsController/Edit/5
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

        // GET: ClientsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientsController/Delete/5
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
