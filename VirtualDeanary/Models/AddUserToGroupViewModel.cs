using System.ComponentModel.DataAnnotations;
using VirtualDeanary.Data.Models;
using VirtualDeanery.Data.Models;

namespace VirtualDeanary.Models
{
    public class AddUserToGroupViewModel
    {
        [Key]
        public int Id { get; set; }

        //public int UserId { get; set; }
        //public User User { get; set; }

        [Required]
        [Range(2019, 2100)]
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
        [Range(2, 5)]
        public int Marks { get; set; }
    }
}
