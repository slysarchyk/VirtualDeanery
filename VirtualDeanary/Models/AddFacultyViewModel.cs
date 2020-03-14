using System.ComponentModel.DataAnnotations;

namespace VirtualDeanary.Models
{
    public class AddFacultyViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FacultyName { get; set; }
    }
}
