using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VirtualDeanary.Data.Models
{
    public class Semester
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SemesterName { get; set; }
        public int Year { get; set; }

        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        [Required]
        public string Degree { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public Semester()
        {
            Courses = new List<Course>();
        }
    }
}
