using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VirtualDeanary.Data.Models;
using VirtualDeanery.Data.Models;

namespace VirtualDeanary.Models
{
    public class AddSubjectViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SubjectName { get; set; }

        public int SemesterId { get; set; }
        public Semester Semester { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; } //Properties for Teacher
    }
}
