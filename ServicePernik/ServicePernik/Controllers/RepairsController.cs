using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePernik.Controllers
{
    public class RepairsController : Controller
    {
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
            return View();
        }

        // POST: RepairsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
