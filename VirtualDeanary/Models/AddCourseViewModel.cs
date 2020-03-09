using System.ComponentModel.DataAnnotations;
using VirtualDeanery.Data.Models;

namespace VirtualDeanary.Models
{
    public class AddCourseViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

