using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VirtualDeanary.Data.Models
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FacultyName { get; set; }

        public virtual ICollection<Semester> Semesters { get; set; }
        public Faculty()
        {
            Semesters = new List<Semester>();
        }
    }
}
