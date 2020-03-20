﻿using System.ComponentModel.DataAnnotations;
using VirtualDeanery.Data.Models;

namespace VirtualDeanary.Data.Models
{
    public class StudentList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public virtual User User { get; set; } //Properties for student
        
        [Required]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        
        public int Mark { get; set; }
    }
}
