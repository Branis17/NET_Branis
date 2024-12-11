namespace mvcTemplate.Models
{
    public enum Major
    {
        CS, IT, MATHS, OTHER
    }

    public class Student
    {
        // Déclaration des variables d'instance
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public int Age { get; set; }

        public double GPA { get; set; }

        public Major Major { get; set; }

        public DateTime AdmissionDate { get; set; }
    }  // Fermeture de la classe Student
}  // Fermeture du namespace
