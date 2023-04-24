using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using AM.ApplicationCore.Domain;

namespace AM.UI.Web.Controllers
{
    public class FlightController : Controller
    {

        IServiceFlight serviceFlight;
        IServicePlane servicePlane;

        public FlightController(IServiceFlight serviceFlight, IServicePlane servicePlane)
        {
            this.serviceFlight = serviceFlight;
            this.servicePlane = servicePlane;
        }
        // GET: Flight
        public ActionResult Index(string destination, string departure)
        {
            var flights = serviceFlight.GetAll();
            if (destination != null && departure!=null)
            {
                flights = flights.Where(f => f.destination.ToUpper().Contains(destination.ToUpper()) && f.departure.ToUpper().Contains(departure.ToUpper()));
            }
            else if (destination == null && departure != null)
            {
                flights = flights.Where(f => f.departure.ToUpper().Contains(departure.ToUpper()));
            }
            else if (destination != null && departure == null)
            {
                flights = flights.Where(f => f.destination.ToUpper().Contains(destination.ToUpper()));
            }
            return View(flights);
        }

        // GET: Flight/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Flight/Create
        public ActionResult Create()
        {
            ViewBag.planes = new SelectList(servicePlane.GetAll(), "information");
            return View();
        }

        // POST: Flight/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight collection)
        {
            try
            {
                serviceFlight.Add(collection);
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Flight/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View();
        }

        // POST: Flight/Edit/5
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

        // GET: Flight/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Flight/Delete/5
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
