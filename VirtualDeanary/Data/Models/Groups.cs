using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VirtualDeanary.Data.Models
{
    public class Groups
    {
        [Key]
        public int Id { get; set; }

        //public int UserId { get; set; }
        //public User User { get; set; }

        [Required]
        [Range(2019,2100)]
        public int Year { get; set; }
        [Required]
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public string Semester { get; set; }
        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        [Range(2,5)]
        public int Marks { get; set; }
    }

    public class Faculty
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FacultyName { get; set; }

        public virtual ICollection<Groups> Groups { get; set; }
        public Faculty()
        {
            Groups = new List<Groups>();
        }
    }

    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CourseName { get; set; }

        public virtual ICollection<Groups> Groups { get; set; }
        public Course()
        {
            Groups = new List<Groups>();
        }
    }
}
