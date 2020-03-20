using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VirtualDeanary.Data.Models
{
    public class Semester
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Period Period { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int StudyYear { get; set; }

        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        [Required]
        public Degree Degree { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
        public Semester()
        {
            Subjects = new List<Subject>();
        }
    }

    public enum Period
    {
        Winter = 1,
        Summer = 2
    }

    public enum Degree
    {
        Bahelor = 1,
        Master = 2
    }
}
