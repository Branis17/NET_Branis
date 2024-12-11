using Microsoft.AspNetCore.Mvc;
using mvcTemplate.Models; 
namespace mvcTemplate.Controllers  
{
    public class StudentController : Controller
    {
        // Création d'une liste statique de Student
        private static List<Student> students = new()
        {
            new() { AdmissionDate = new DateTime(2021, 9, 1), Age = 20, Firstname = "John", GPA = 3.5, Id = 1, Lastname = "Doe", Major = Major.CS },
            new() { AdmissionDate = new DateTime(2021, 9, 1), Age = 20, Firstname = "Jane", GPA = 3.8, Id = 2, Lastname = "Smith", Major = Major.IT },
            new() { AdmissionDate = new DateTime(2022, 1, 10), Age = 22, Firstname = "Alice", GPA = 3.9, Id = 3, Lastname = "Johnson", Major = Major.MATHS },
            new() { AdmissionDate = new DateTime(2023, 9, 1), Age = 19, Firstname = "Bob", GPA = 3.2, Id = 4, Lastname = "Brown", Major = Major.OTHER }
        };

        // GET: StudentController
        public ActionResult Index()
        {
            return View(students);
        }
    }
}
