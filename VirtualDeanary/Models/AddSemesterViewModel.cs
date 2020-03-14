using System.ComponentModel.DataAnnotations;
using VirtualDeanary.Data.Models;

namespace VirtualDeanary.Models
{
    public class AddSemesterViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SemesterName { get; set; }
        public int Year { get; set; }

        public int FacultyId { get; set; }

        [Required]
        public string Degree { get; set; }
    }
}
