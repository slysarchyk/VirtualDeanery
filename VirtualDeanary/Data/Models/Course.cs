using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VirtualDeanery.Data.Models;

namespace VirtualDeanary.Data.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CourseName { get; set; }

        public int SemesterId { get; set; }
        public Semester Semester { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; } //Properties for Teacher

        public virtual ICollection<StudentList> Marks { get; set; }
        public Course()
        {
            Marks = new List<StudentList>();
        }
    }
}
