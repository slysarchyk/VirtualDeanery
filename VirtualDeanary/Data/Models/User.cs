using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace VirtualDeanery.Data.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Year { get; set; }

        //public virtual ICollection<Group> Groups { get; set; }
        //public User()
        //{
        //    Groups = new List<Group>();
        //}
    }
}
