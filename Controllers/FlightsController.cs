using Flight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Flight.Controllers
{
    public class FlightsController : Controller
    {
        private readonly FlightContext _context;

        public FlightsController(FlightContext context)
        {
            _context = context;
        }

        private static readonly string[] Cities =
        {
            "Chicago",
            "New York",
            "Dubai",
            "London",
            "Hong Kong",
            "San Francisco"
        };

        private void LoadCities(string? from = null, string? to = null)
        {
            ViewBag.FromList = new SelectList(Cities, from);
            ViewBag.ToList = new SelectList(Cities, to);
        }

        public IActionResult List()
        {
            return View(_context.Flights.ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            LoadCities();
            ViewBag.Action = "Add";
            return View("AddEdit", new FlightModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(FlightModel flight)
        {
            if (!ModelState.IsValid)
            {
                LoadCities(flight.FromCity, flight.ToCity);
                ViewBag.Action = "Add";
                return View("AddEdit", flight);
            }

            _context.Flights.Add(flight);
            _context.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var flight = _context.Flights.Find(id);
            if (flight == null) return NotFound();

            LoadCities(flight.FromCity, flight.ToCity);
            ViewBag.Action = "Edit";
            return View("AddEdit", flight);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FlightModel flight)
        {
            var existing = _context.Flights.Find(flight.FlightNumber);
            if (existing == null) return NotFound();

            existing.FromCity = flight.FromCity;
            existing.ToCity = flight.ToCity;
            existing.Date = flight.Date;
            existing.Price = flight.Price;

            _context.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var flight = _context.Flights.Find(id);
            if (flight == null) return NotFound();

            return View("DeleteConfirm", flight);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string flightNumber)
        {
            var flight = _context.Flights.Find(flightNumber);
            if (flight == null) return NotFound();

            _context.Flights.Remove(flight);
            _context.SaveChanges();

            return RedirectToAction("List");
        }
    }
}