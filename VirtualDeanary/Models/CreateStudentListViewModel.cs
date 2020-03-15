using System.ComponentModel.DataAnnotations;
using VirtualDeanary.Data.Models;
using VirtualDeanery.Data.Models;

namespace VirtualDeanary.Models
{
    public class CreateStudentListViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public virtual User User { get; set; } //Properties for student

        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int Marks { get; set; }
    }
}