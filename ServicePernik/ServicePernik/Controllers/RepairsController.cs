using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicePernik.Abstractions;
using ServicePernik.Models.Repair;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePernik.Controllers
{
    public class RepairsController : Controller
    {
        private readonly IRepairService _repairService;
        public RepairsController(IRepairService repairService)
        {
            _repairService = repairService;
        }
        // GET: RepairsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RepairsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RepairsController/Create
        public ActionResult Create()
        {
            var repairs = _repairService.GetRepairs()
                  .Select(u => new AllRepairsVM
                  {
                      Id = u.Id,
                      Code = u.Code,
                      Name = u.Name,
                      Price = u.Price,
                      Description = u.Description
                  }).ToList();

            return this.View(repairs);
        }

        // POST: RepairsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddRepairVM model)
        {          
            var created = _repairService.CreateRepair(model.Code, model.Name, model.RepairCategoryId, model.Price, model.Description);
            if (created)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: RepairsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RepairsController/Edit/5
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

        // GET: RepairsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RepairsController/Delete/5
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
