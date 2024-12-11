using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using System.Collections.Generic;
using System.Linq;
using mvcTemplate.Models;
using mvcTemplate.Data;



public class TeacherController : Controller
{
    private readonly AppDbContext _context;

    // Injection du contexte de base de données
    public TeacherController(AppDbContext context)
    {
        _context = context;
    }

    // Afficher la liste des enseignants
    public IActionResult Index()
    {
        var teachers = _context.Teachers.ToList(); // Récupère tous les enseignants depuis la BDD
        return View(teachers);
    }

    // Afficher la vue de création d'un enseignant
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // Ajouter un enseignant dans la BDD
    [HttpPost]
    public IActionResult Create(Teacher teacher)
    {
        if (!ModelState.IsValid)
        {
            return View(teacher);
        }

        _context.Teachers.Add(teacher); // Ajoute l'enseignant
        _context.SaveChanges();        // Sauvegarde dans la BDD
        return RedirectToAction(nameof(Index));
    }

    // Afficher les détails d'un enseignant
    public IActionResult Details(int id)
    {
        var teacher = _context.Teachers.Find(id); // Recherche par ID dans la BDD
        if (teacher == null) return NotFound();
        return View(teacher);
    }

    // Afficher la vue d'édition d'un enseignant
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var teacher = _context.Teachers.Find(id); // Recherche par ID
        if (teacher == null) return NotFound();
        return View(teacher);
    }

    // Modifier un enseignant dans la BDD
    [HttpPost]
    public IActionResult Edit(Teacher updatedTeacher)
    {
        if (!ModelState.IsValid)
        {
            return View(updatedTeacher);
        }

        _context.Teachers.Update(updatedTeacher); // Mise à jour
        _context.SaveChanges();                  // Sauvegarde
        return RedirectToAction(nameof(Index));
    }

    // Supprimer un enseignant
    public IActionResult Delete(int id)
    {
        var teacher = _context.Teachers.Find(id); // Recherche par ID
        if (teacher == null) return NotFound();

        _context.Teachers.Remove(teacher); // Suppression
        _context.SaveChanges();           // Sauvegarde
        return RedirectToAction(nameof(Index));
    }
}

    /*// Liste d'enseignants (en dur)
    private static List<Teacher> Teachers = new List<Teacher>
    {
        new Teacher { Id = 1, Name = "Kaci", Namesc = "Branis", Age = 20 },
        new Teacher { Id = 2, Name = "AITMAHAMED", Namesc = "Massinissa", Age = 20 }
    };

    
    public IActionResult Index()
    {
        return View(Teachers);
    }

    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    /*[HttpPost]
    public IActionResult Create(Teacher teacher)
    {
        teacher.Id = Teachers.Count + 1;
        Teachers.Add(teacher);
        return RedirectToAction(nameof(Index));
    }


    [HttpPost]
    public IActionResult Create(Teacher teacher)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        teacher.Id = Teachers.Count + 1; 
        Teachers.Add(teacher);
        return RedirectToAction(nameof(Index));
    }

    
    public IActionResult Details(int id)
    {
        var teacher = Teachers.Find(t => t.Id == id);
        if (teacher == null) return NotFound();
        return View(teacher);
    }

    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var teacher = Teachers.Find(t => t.Id == id);
        if (teacher == null) return NotFound();
        return View(teacher);
    }

  
    [HttpPost]
    public IActionResult Edit(Teacher updatedTeacher)
    {
        var teacher = Teachers.Find(t => t.Id == updatedTeacher.Id);
        if (teacher == null) return NotFound();

        teacher.Name = updatedTeacher.Name;
        teacher.Namesc = updatedTeacher.Namesc;
        teacher.Age = updatedTeacher.Age;

        return RedirectToAction(nameof(Index));
    }

   
    public IActionResult Delete(int id)
    {
        var teacher = Teachers.Find(t => t.Id == id);
        if (teacher == null) return NotFound();

        Teachers.Remove(teacher);
        return RedirectToAction(nameof(Index));
    }*/

