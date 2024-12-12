using Microsoft.AspNetCore.Mvc;
using mvcTemplate.Data;
using mvcTemplate.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace mvcTemplate.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _context;

        public EventController(AppDbContext context)
        {
            _context = context;
        }

       
        [Authorize(Roles = "Teacher,Student")]
        public IActionResult Index()
        {
           
            if (!User.IsInRole("Student") && !User.IsInRole("Teacher"))
            {
                return RedirectToAction("Unauthorized", "Shared");
            }

            var events = _context.Events.OrderBy(e => e.EventDate).ToList(); 
            return View(events);
        }

        
        [Authorize(Roles = "Teacher")]
        public IActionResult Details(int id)
        {
            var eventItem = _context.Events.FirstOrDefault(e => e.Id == id);
            if (eventItem == null) return NotFound();
            return View(eventItem);
        }

       
        [Authorize(Roles = "Teacher")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event eventItem)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(eventItem);
                _context.SaveChanges();
                TempData["Message"] = "Événement ajouté avec succès !";
                return RedirectToAction(nameof(Index));
            }
            return View(eventItem);
        }

        
        [Authorize(Roles = "Teacher")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var eventItem = _context.Events.FirstOrDefault(e => e.Id == id);
            if (eventItem == null) return NotFound();
            return View(eventItem);
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Event eventItem)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Update(eventItem);
                _context.SaveChanges();
                TempData["Message"] = "Événement modifié avec succès !";
                return RedirectToAction(nameof(Index));
            }
            return View(eventItem);
        }

       
        [Authorize(Roles = "Teacher")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var eventItem = _context.Events.FirstOrDefault(e => e.Id == id);
            if (eventItem == null) return NotFound();
            return View(eventItem);
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var eventItem = _context.Events.FirstOrDefault(e => e.Id == id);
            if (eventItem == null) return NotFound();

            _context.Events.Remove(eventItem);
            _context.SaveChanges();
            TempData["Message"] = "Événement supprimé avec succès !";
            return RedirectToAction(nameof(Index));
        }

        
        public IActionResult Unauthorized()
        {
            return View();
        }
    }
}
