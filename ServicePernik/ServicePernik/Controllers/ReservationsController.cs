using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicePernik.Abstractions;
using ServicePernik.Data;
using ServicePernik.Entities;
using ServicePernik.Models.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServicePernik.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IHourService _hourService;
        private readonly ApplicationDbContext _context;
        public ReservationsController(IReservationService reservationService, IHourService hourService, ApplicationDbContext context)
        {
            _reservationService = reservationService;
            _hourService = hourService;
            _context = context;
        }
        // GET: ReservationsController
        public ActionResult Index()
        {
            List<AllReservationsVM> reservations = _reservationService.GetReservations()
               .Select(item => new AllReservationsVM()
               {
                   Id = item.Id,
                   HourId = item.HourId,
                   Hour=item.Hour.FreeHour.ToString(),
                   Description = item.Description,
                   ClientId=item.ClientId,
                   ClientFullName=item.Client.FirstName+" "+item.Client.LastName,
                   StatusReservationId=item.StatusReservationId,
                   StatusReservationName=item.StatusReservation.Name,
                   DateReservation =item.DateReservation,

               }).ToList();
            return View(reservations);
        }

        public ActionResult My()
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<AllReservationsVM> reservations = _reservationService.GetReservations()
                .Where(x=>x.Client.UserId==currentUserId)
               .Select(item => new AllReservationsVM()
               {
                   Id = item.Id,
                   HourId = item.HourId,
                   Hour = item.Hour.FreeHour.ToString(),
                   Description = item.Description,
                   ClientId = item.ClientId,
                   ClientFullName = item.Client.FirstName + " " + item.Client.LastName,
                   StatusReservationId = item.StatusReservationId,
                   StatusReservationName = item.StatusReservation.Name,
                   DateReservation = item.DateReservation,

               }).ToList();
            return View(reservations);
        }

        // GET: ReservationsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReservationsController/Create
        public ActionResult Create(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Hour item = _hourService.GetHourById(id);
            if (item == null)
            {
                return NotFound();
            }
            AddReservationVM reservation = new AddReservationVM()
            {
                HourId = item.Id
            };
            return View(reservation);

        }

        // POST: ReservationsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, AddReservationVM model)
        {
            if (!this.ModelState.IsValid)
            {
                return NotFound();
            }
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var created = _reservationService.CreateReservation(id, currentUserId, model.Description);
            if (created)
            {
                return RedirectToAction(nameof(My));
            }
            else
            {
                return View();
            }
        }

        // GET: ReservationsController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reservation item = _context.Reservations.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            EditReservationVM reservation = new EditReservationVM()
            {
                Id = item.Id,
                DateReservation = item.DateReservation,
                HourId = item.HourId,
                StatusReservationId=item.StatusReservationId,
                ClientId=item.ClientId,
                Description=item.Description,
             
            };
            return View(reservation);
        }

        // POST: ReservationsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditReservationVM bindingModel)
        {
            if (ModelState.IsValid)
            {
                Reservation reservation = new Reservation
                {
                    Id = bindingModel.Id,
                    DateReservation = bindingModel.DateReservation,
                    HourId = bindingModel.HourId,
                    StatusReservationId = bindingModel.StatusReservationId,
                    ClientId=bindingModel.ClientId,
                    Description=bindingModel.Description
                };
                _context.Reservations.Update(reservation);
                _context.SaveChanges();
                return this.RedirectToAction("Index");
            }
            return View(bindingModel);
        }

        // GET: ReservationsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservationsController/Delete/5
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
