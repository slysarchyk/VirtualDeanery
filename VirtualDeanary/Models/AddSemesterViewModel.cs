using System.ComponentModel.DataAnnotations;
using VirtualDeanary.Data.Models;

namespace VirtualDeanary.Models
{
    public class AddSemesterViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Period { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int StudyYear { get; set; }

        public int FacultyId { get; set; }

        [Required]
        public string Degree { get; set; }
    }
}
