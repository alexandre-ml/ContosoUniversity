using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public enum Grid
    {
        A, B, C, D, E, F
    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }

        [DisplayFormat(NullDisplayText = "No Grid")]
        public Grid? Grid { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
