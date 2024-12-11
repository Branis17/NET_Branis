using Microsoft.AspNetCore.Mvc;
using mvcTemplate.Data;
using mvcTemplate.Models;
using System.Linq;

namespace mvcTemplate.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        // Afficher la liste des �tudiants
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        // D�tails d'un �tudiant
        public IActionResult Details(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return View(student);
        }

        // Ajouter un �tudiant - GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Ajouter un �tudiant - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                TempData["Message"] = "�tudiant ajout� avec succ�s !";
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // Modifier un �tudiant - GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return View(student);
        }

        // Modifier un �tudiant - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                TempData["Message"] = "�tudiant modifi� avec succ�s !";
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // Supprimer un �tudiant - GET
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return View(student);
        }

        // Supprimer un �tudiant - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();

            _context.Students.Remove(student);
            _context.SaveChanges();
            TempData["Message"] = "�tudiant supprim� avec succ�s !";
            return RedirectToAction(nameof(Index));
        }
    }
}
