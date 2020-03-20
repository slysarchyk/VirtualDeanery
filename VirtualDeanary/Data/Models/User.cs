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
        public bool Teacher { get; set; }

        //public int FacultyId { get; set; }
        //public Faculty Faculty { get; set; }

        public virtual ICollection<StudentList> Marks { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public User()
        {
            Marks = new List<StudentList>();
            Subjects = new List<Subject>();
        }
    }
}
