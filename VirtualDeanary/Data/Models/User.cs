using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using VirtualDeanary.Data.Models;

namespace VirtualDeanery.Data.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Year { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public User()
        {
            Marks = new List<Mark>();
            Courses = new List<Course>();
        }
    }
}
