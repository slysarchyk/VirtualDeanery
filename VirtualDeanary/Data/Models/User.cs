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

        public virtual ICollection<Groups> Groups { get; set; }
        public User()
        {
            Groups = new List<Groups>();
        }
    }
}
